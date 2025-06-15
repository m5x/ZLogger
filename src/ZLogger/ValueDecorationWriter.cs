using System.Buffers;
using Utf8StringInterpolation;

namespace ZLogger;

public delegate void ValueDecorationWriter(bool isSuffix, object? value, ref Utf8StringWriter<IBufferWriter<byte>> writer);
