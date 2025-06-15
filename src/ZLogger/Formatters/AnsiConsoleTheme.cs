using System.Buffers;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Extensions.Logging;
using Utf8StringInterpolation;

namespace ZLogger.Formatters;

/// <summary>
/// A console theme using the ANSI terminal escape sequences. Recommended
/// for Linux and Windows 10+.
///
/// Based on code from https://github.com/serilog/serilog-sinks-console project.
/// </summary>
public class AnsiConsoleTheme
{
    const string AnsiStyleReset = "\x1b[0m";
    readonly string[] styles;

    /// <summary>
    /// Construct a theme given a set of styles.
    /// </summary>
    /// <param name="styles">Styles to apply within the theme.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="styles"/> is <code>null</code></exception>
    public AnsiConsoleTheme(IReadOnlyDictionary<ConsoleThemeStyle, string> styles)
    {
        if (styles is null) throw new ArgumentNullException(nameof(styles));

        var styleCount = styles.Count;
        this.styles = new string[styleCount];
        foreach( var pair in styles )
        {
            var index = (int)pair.Key;
            if( index < 0 || index >= styleCount )
                throw new ArgumentException("Supplied styles contain an invalid style index.", nameof(styles));

            this.styles[index] = pair.Value;
        }
    }

    public string this[ConsoleThemeStyle style] => styles[(int)style];

    public string AnsiStyleResetCode => AnsiStyleReset;

    public string TimestampAnsiStyleCode => styles[(int)ConsoleThemeStyle.SecondaryText];

    public string CategoryAnsiStyleCode => styles[(int)ConsoleThemeStyle.TertiaryText];

    public string GetLogLevelAnsiStyleCode( LogLevel logLevel )
    {
        return logLevel switch
        {
            LogLevel.Trace       => styles[(int)ConsoleThemeStyle.LevelVerbose],
            LogLevel.Debug       => styles[(int)ConsoleThemeStyle.LevelDebug],
            LogLevel.Information => styles[(int)ConsoleThemeStyle.LevelInformation],
            LogLevel.Warning     => styles[(int)ConsoleThemeStyle.LevelWarning],
            LogLevel.Error       => styles[(int)ConsoleThemeStyle.LevelError],
            LogLevel.Critical    => styles[(int)ConsoleThemeStyle.LevelFatal],
            _                    => styles[(int)ConsoleThemeStyle.Invalid]
        };
    }

    public void WriteValueDecoration( bool isSuffix, object? value, ref Utf8StringWriter<IBufferWriter<byte>> writer )
    {
        writer.Append( isSuffix ? AnsiStyleReset : Convert.GetTypeCode( value?.GetType() ) switch
        {
            >= TypeCode.SByte and <= TypeCode.Decimal => styles[(int)ConsoleThemeStyle.Number],
            TypeCode.String                           => styles[(int)ConsoleThemeStyle.String],
            TypeCode.Boolean                          => styles[(int)ConsoleThemeStyle.Boolean],
            _                                         => styles[(int)ConsoleThemeStyle.Scalar]
        });
    }
}
