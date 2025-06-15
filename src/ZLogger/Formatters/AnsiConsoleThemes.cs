namespace ZLogger.Formatters;

public static class AnsiConsoleThemes
{
    #region Serilog sink themes

    // Themes in this region come from https://github.com/serilog/serilog-sinks-console project.

    /// <summary>
    /// A theme in the style of the original <i>Serilog.Sinks.Literate</i>.
    /// </summary>
    public static AnsiConsoleTheme Literate { get; } = new(
    new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\x1b[38;5;0015m",
        [ConsoleThemeStyle.SecondaryText] = "\x1b[38;5;0007m",
        [ConsoleThemeStyle.TertiaryText] = "\x1b[38;5;0008m",
        [ConsoleThemeStyle.Invalid] = "\x1b[38;5;0011m",
        [ConsoleThemeStyle.Null] = "\x1b[38;5;0027m",
        [ConsoleThemeStyle.Name] = "\x1b[38;5;0007m",
        [ConsoleThemeStyle.String] = "\x1b[38;5;0045m",
        [ConsoleThemeStyle.Number] = "\x1b[38;5;0200m",
        [ConsoleThemeStyle.Boolean] = "\x1b[38;5;0027m",
        [ConsoleThemeStyle.Scalar] = "\x1b[38;5;0085m",
        [ConsoleThemeStyle.LevelVerbose] = "\x1b[38;5;0007m",
        [ConsoleThemeStyle.LevelDebug] = "\x1b[38;5;0007m",
        [ConsoleThemeStyle.LevelInformation] = "\x1b[38;5;0015m",
        [ConsoleThemeStyle.LevelWarning] = "\x1b[38;5;0011m",
        [ConsoleThemeStyle.LevelError] = "\x1b[38;5;0015m\x1b[48;5;0196m",
        [ConsoleThemeStyle.LevelFatal] = "\x1b[38;5;0015m\x1b[48;5;0196m",
    });

    /// <summary>
    /// A theme using only gray, black and white.
    /// </summary>
    public static AnsiConsoleTheme Grayscale { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\x1b[37;1m",
        [ConsoleThemeStyle.SecondaryText] = "\x1b[37m",
        [ConsoleThemeStyle.TertiaryText] = "\x1b[30;1m",
        [ConsoleThemeStyle.Invalid] = "\x1b[37;1m\x1b[47m",
        [ConsoleThemeStyle.Null] = "\x1b[1m\x1b[37;1m",
        [ConsoleThemeStyle.Name] = "\x1b[37m",
        [ConsoleThemeStyle.String] = "\x1b[1m\x1b[37;1m",
        [ConsoleThemeStyle.Number] = "\x1b[1m\x1b[37;1m",
        [ConsoleThemeStyle.Boolean] = "\x1b[1m\x1b[37;1m",
        [ConsoleThemeStyle.Scalar] = "\x1b[1m\x1b[37;1m",
        [ConsoleThemeStyle.LevelVerbose] = "\x1b[30;1m",
        [ConsoleThemeStyle.LevelDebug] = "\x1b[30;1m",
        [ConsoleThemeStyle.LevelInformation] = "\x1b[37;1m",
        [ConsoleThemeStyle.LevelWarning] = "\x1b[37;1m\x1b[47m",
        [ConsoleThemeStyle.LevelError] = "\x1b[30m\x1b[47m",
        [ConsoleThemeStyle.LevelFatal] = "\x1b[30m\x1b[47m",
    });

    /// <summary>
    /// A 256-color theme along the lines of Visual Studio Code.
    /// </summary>
    public static AnsiConsoleTheme Code { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\x1b[38;5;0253m",
        [ConsoleThemeStyle.SecondaryText] = "\x1b[38;5;0246m",
        [ConsoleThemeStyle.TertiaryText] = "\x1b[38;5;0242m",
        [ConsoleThemeStyle.Invalid] = "\x1b[33;1m",
        [ConsoleThemeStyle.Null] = "\x1b[38;5;0038m",
        [ConsoleThemeStyle.Name] = "\x1b[38;5;0081m",
        [ConsoleThemeStyle.String] = "\x1b[38;5;0216m",
        [ConsoleThemeStyle.Number] = "\x1b[38;5;151m",
        [ConsoleThemeStyle.Boolean] = "\x1b[38;5;0038m",
        [ConsoleThemeStyle.Scalar] = "\x1b[38;5;0079m",
        [ConsoleThemeStyle.LevelVerbose] = "\x1b[37m",
        [ConsoleThemeStyle.LevelDebug] = "\x1b[37m",
        [ConsoleThemeStyle.LevelInformation] = "\x1b[37;1m",
        [ConsoleThemeStyle.LevelWarning] = "\x1b[38;5;0229m",
        [ConsoleThemeStyle.LevelError] = "\x1b[38;5;0197m\x1b[48;5;0238m",
        [ConsoleThemeStyle.LevelFatal] = "\x1b[38;5;0197m\x1b[48;5;0238m",
    });

    /// <summary>
    /// A theme in the style of the original <i>Serilog.Sinks.Literate</i> using only standard 16 terminal colors that will work on light backgrounds.
    /// </summary>
    public static AnsiConsoleTheme Sixteen { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = AnsiEscapeSequence.Unthemed,
        [ConsoleThemeStyle.SecondaryText] = AnsiEscapeSequence.Unthemed,
        [ConsoleThemeStyle.TertiaryText] = AnsiEscapeSequence.Unthemed,
        [ConsoleThemeStyle.Invalid] = AnsiEscapeSequence.Yellow,
        [ConsoleThemeStyle.Null] = AnsiEscapeSequence.Blue,
        [ConsoleThemeStyle.Name] = AnsiEscapeSequence.Unthemed,
        [ConsoleThemeStyle.String] = AnsiEscapeSequence.Cyan,
        [ConsoleThemeStyle.Number] = AnsiEscapeSequence.Magenta,
        [ConsoleThemeStyle.Boolean] = AnsiEscapeSequence.Blue,
        [ConsoleThemeStyle.Scalar] = AnsiEscapeSequence.Green,
        [ConsoleThemeStyle.LevelVerbose] = AnsiEscapeSequence.Unthemed,
        [ConsoleThemeStyle.LevelDebug] = AnsiEscapeSequence.Bold,
        [ConsoleThemeStyle.LevelInformation] = AnsiEscapeSequence.BrightCyan,
        [ConsoleThemeStyle.LevelWarning] = AnsiEscapeSequence.BrightYellow,
        [ConsoleThemeStyle.LevelError] = AnsiEscapeSequence.BrightRed,
        [ConsoleThemeStyle.LevelFatal] = AnsiEscapeSequence.BrightRed,
    });

    #endregion

    #region BlackBytesBox themes

    // Themes in this region come from https://github.com/carsten-riedel/BlackBytesBox.Serilog.AnsiConsoleThemes project.

    /// <summary>
    /// Clarion Dusk: An artfully designed Serilog console theme, brought to life with insights from OpenAI.
    /// This theme marries enhanced readability with a refined color palette, meticulously curated to distinguish various log levels and essential details with ease.
    /// Perfect for developers seeking to transform their log data into a clear and compelling visual narrative, Clarion Dusk is your companion in the journey towards effortless monitoring and stylish diagnostics.
    /// Experience the blend of art and functionality, designed to elevate your logging experience.
    /// </summary>
    public static AnsiConsoleTheme ClarionDusk { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\u001b[38;5;231m",
        [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;250m",
        [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;246m",
        [ConsoleThemeStyle.Invalid] = "\u001b[38;5;160m",
        [ConsoleThemeStyle.Null] = "\u001b[38;5;59m",
        [ConsoleThemeStyle.Name] = "\u001b[38;5;45m",
        [ConsoleThemeStyle.String] = "\u001b[38;5;186m",
        [ConsoleThemeStyle.Number] = "\u001b[38;5;220m",
        [ConsoleThemeStyle.Boolean] = "\u001b[38;5;39m",
        [ConsoleThemeStyle.Scalar] = "\u001b[38;5;78m",
        [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;244m",
        [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;81m",
        [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;76m",
        [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;226m",
        [ConsoleThemeStyle.LevelError] = "\u001b[38;5;202m",
        [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;198m\u001b[48;5;52m",
    });

    /// <summary>
    /// VisualStudioNight: Console theme that more closely emulates
    /// the default Visual Studio dark style colors.
    /// </summary>
    /// <remarks>
    /// Colors have been chosen to reflect typical Visual Studio dark theme color
    /// values, approximated for the 256-color xterm palette.
    /// </remarks>
    public static AnsiConsoleTheme CodingNight { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        // Regular text: near #D4D4D4
        [ConsoleThemeStyle.Text] = "\u001b[38;5;252m",         // approx. #D0D0D0
        // Secondary text: near #808080
        [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;244m", // #808080
        // Tertiary text: a darker gray
        [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;240m",  // #585858
        // Invalid (e.g. exceptions): near #F44747
        [ConsoleThemeStyle.Invalid] = "\u001b[38;5;203m",       // #FF5F5F
        // Null values: a medium gray
        [ConsoleThemeStyle.Null] = "\u001b[38;5;242m",          // #767676
        // Property/field names: near #569CD6
        [ConsoleThemeStyle.Name] = "\u001b[38;5;74m",           // #5FAFDF
        // String values: near #CE9178
        [ConsoleThemeStyle.String] = "\u001b[38;5;173m",        // #D7875F
        // Numbers: near #B5CEA8
        [ConsoleThemeStyle.Number] = "\u001b[38;5;150m",        // #AFD787
        // Booleans: near #4EC9B0
        [ConsoleThemeStyle.Boolean] = "\u001b[38;5;72m",        // #5FD7AF
        // Other scalar values
        [ConsoleThemeStyle.Scalar] = "\u001b[38;5;72m",         // #5FD7AF
        // Verbose logs: gray
        [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;244m",  // #808080
        // Debug logs: near #9CDCFE
        [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;117m",    // #87D7FF
        // Info logs: a soft gold/brown
        [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;179m", // #D7AF5F
        // Warning logs: near #DCDCAA
        [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;187m",  // #D7D7AF
        // Error logs: near #F44747
        [ConsoleThemeStyle.LevelError] = "\u001b[38;5;203m",    // #FF5F5F
        // Fatal logs: bright foreground on dark red background
        [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;203m\u001b[48;5;52m", // #FF5F5F on #5F0000
    });

    /// <summary>
    /// Gets a fancy professional variant with a sleek, modern aesthetic.
    /// </summary>
    /// <remarks>
    /// This theme is designed for high contrast and refined styling,
    /// featuring bright white text, subtle greys, and distinctive colors for each log level.
    /// </remarks>
    public static AnsiConsoleTheme ProfessionalNoir { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\u001b[38;5;255m",          // Bright white for primary text
        [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;250m",   // Light grey for secondary text
        [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;245m",    // Muted grey for tertiary text
        [ConsoleThemeStyle.Invalid] = "\u001b[38;5;160m",         // Soft red for invalid content
        [ConsoleThemeStyle.Null] = "\u001b[38;5;59m",             // Dim cyan for null values
        [ConsoleThemeStyle.Name] = "\u001b[38;5;75m",             // Calm teal for names/identifiers
        [ConsoleThemeStyle.String] = "\u001b[38;5;183m",          // Warm lavender for strings
        [ConsoleThemeStyle.Number] = "\u001b[38;5;220m",          // Vibrant yellow for numbers
        [ConsoleThemeStyle.Boolean] = "\u001b[38;5;82m",          // Crisp green for booleans
        [ConsoleThemeStyle.Scalar] = "\u001b[38;5;150m",          // Soft blue for scalar values
        [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;244m",    // Subtle grey for verbose logs
        [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;39m",       // Distinguished blue for debug logs
        [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;117m",// Refined cyan for informational logs
        [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;214m",    // Bold orange for warnings
        [ConsoleThemeStyle.LevelError] = "\u001b[38;5;203m",      // Strong red for errors
        [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;196m\u001b[48;5;52m", // Intense red on a dark background for fatal errors
    });

    /// <summary>
    /// RetroGreen: evokes the look of monochrome CRT terminals circa 1980-1990.<br/>
    /// &lt;remarks&gt;Ideal when you need that nostalgic hacker-movie vibe while retaining clear log-level separation.&lt;/remarks&gt;
    /// </summary>
    /// <returns>An <see cref="AnsiConsoleTheme"/> configured with green-centric ANSI colors.</returns>
    /// <example>
    /// &lt;code&gt;
    /// Log.Logger = new LoggerConfiguration()
    ///     .WriteTo.Console(theme: CustomThemes.RetroGreen)
    ///     .CreateLogger();
    /// &lt;/code&gt;
    /// </example>
    public static AnsiConsoleTheme RetroGreen { get; } = new(new Dictionary<ConsoleThemeStyle, string>
    {
        [ConsoleThemeStyle.Text] = "\u001b[38;5;34m",  // medium green
        [ConsoleThemeStyle.SecondaryText] = "\u001b[38;5;29m",
        [ConsoleThemeStyle.TertiaryText] = "\u001b[38;5;22m",

        [ConsoleThemeStyle.Invalid] = "\u001b[38;5;82m\u001b[48;5;22m",
        [ConsoleThemeStyle.Null] = "\u001b[38;5;22m",
        [ConsoleThemeStyle.Name] = "\u001b[38;5;76m",
        [ConsoleThemeStyle.String] = "\u001b[38;5;70m",
        [ConsoleThemeStyle.Number] = "\u001b[38;5;34m",
        [ConsoleThemeStyle.Boolean] = "\u001b[38;5;76m",
        [ConsoleThemeStyle.Scalar] = "\u001b[38;5;70m",

        [ConsoleThemeStyle.LevelVerbose] = "\u001b[38;5;22m",
        [ConsoleThemeStyle.LevelDebug] = "\u001b[38;5;29m",
        [ConsoleThemeStyle.LevelInformation] = "\u001b[38;5;34m",
        [ConsoleThemeStyle.LevelWarning] = "\u001b[38;5;70m",
        [ConsoleThemeStyle.LevelError] = "\u001b[38;5;76m\u001b[48;5;22m",
        [ConsoleThemeStyle.LevelFatal] = "\u001b[38;5;231m\u001b[48;5;28m",  // white on dark green
    });

    #endregion
}
