using System.Buffers;
using System.Text;
using Microsoft.Extensions.Logging;
using ZLogger.Internal;

namespace ZLogger.Formatters
{
    public delegate void AnsiConsoleMessageTemplateFormatter(in MessageTemplate template, in LogInfo info, in AnsiConsoleTheme theme);

    public class AnsiConsoleZLoggerFormatter : IZLoggerFormatter
    {
        static readonly byte[] newLine = Encoding.UTF8.GetBytes(Environment.NewLine);

        public bool WithLineBreak => true;

        Action<IBufferWriter<byte>, Exception> exceptionFormatter = DefaultExceptionLoggingFormatter;

        MessageTemplateHolder? prefixTemplate;
        AnsiConsoleMessageTemplateFormatter? prefixFormatter;
        MessageTemplateHolder? suffixTemplate;
        AnsiConsoleMessageTemplateFormatter? suffixFormatter;

        public AnsiConsoleTheme Theme { get; set; } = AnsiConsoleThemes.Code;

        public void SetPrefixFormatter(MessageTemplateHandler format, AnsiConsoleMessageTemplateFormatter formatter)
        {
            this.prefixTemplate = format.GetTemplate();
            this.prefixFormatter = formatter;
        }

        public void SetSuffixFormatter(MessageTemplateHandler format, AnsiConsoleMessageTemplateFormatter formatter)
        {
            this.suffixTemplate = format.GetTemplate();
            this.suffixFormatter = formatter;
        }

        public void SetExceptionFormatter(Action<IBufferWriter<byte>, Exception> formatter)
        {
            this.exceptionFormatter = formatter;
        }

        public void FormatLogEntry(IBufferWriter<byte> writer, IZLoggerEntry entry)
        {
            if (prefixTemplate != null)
            {
                prefixFormatter!(new MessageTemplate(prefixTemplate, writer), entry.LogInfo, Theme);
            }

            entry.ToString(writer, Theme.WriteValueDecoration);

            if (suffixTemplate != null)
            {
                suffixFormatter!(new MessageTemplate(suffixTemplate, writer), entry.LogInfo, Theme);
            }

            if (entry.LogInfo.Exception is { } ex)
            {
                exceptionFormatter(writer, ex);
            }
        }

        static void DefaultExceptionLoggingFormatter(IBufferWriter<byte> writer, Exception exception)
        {
            // \n + exception
            Write(writer, newLine);
            WriteExceptionLoggingCore(writer, exception);
        }

        static void WriteExceptionLoggingCore(IBufferWriter<byte> writer, Exception exception)
        {
            // className: message
            //  ---> InnerException
            // InnerException StackTrace
            // --- End of inner exception stack trace ---
            // StackTrace

            var className = exception.GetType().FullName;
            var message = exception.Message;
            var innerException = exception.InnerException;
            var stackTrace = exception.StackTrace; // allocating stacktrace string but okay(shoganai).

            Write(writer, className!, ": ", message ?? "");
            if (innerException != null)
            {
                Write(writer, newLine, " ---> ");
                WriteExceptionLoggingCore(writer, innerException);
                Write(writer, newLine, "   --- End of inner exception stack trace ---");
            }

            if (stackTrace != null)
            {
                Write(writer, newLine, stackTrace);
            }
        }

        static void Write(IBufferWriter<byte> writer, ReadOnlySpan<byte> value)
        {
            var span = writer.GetSpan(value.Length);
            value.CopyTo(span);
            writer.Advance(value.Length);
        }

        static void Write(IBufferWriter<byte> writer, ReadOnlySpan<byte> message1, string message2)
        {
            var span = writer.GetSpan(message1.Length + Encoding.UTF8.GetMaxByteCount(message2.Length));
            message1.CopyTo(span);
            var written2 = Encoding.UTF8.GetBytes(message2.AsSpan(), span.Slice(message1.Length));
            writer.Advance(message1.Length + written2);
        }

        static void Write(IBufferWriter<byte> writer, string message1, string message2, string message3)
        {
            var span = writer.GetSpan(Encoding.UTF8.GetMaxByteCount(message1.Length + message2.Length + message3.Length));

            var written1 = Encoding.UTF8.GetBytes(message1.AsSpan(), span);
            var written2 = Encoding.UTF8.GetBytes(message2.AsSpan(), span.Slice(written1));
            var written3 = Encoding.UTF8.GetBytes(message3.AsSpan(), span.Slice(written1 + written2));
            writer.Advance(written1 + written2 + written3);
        }
    }
}
