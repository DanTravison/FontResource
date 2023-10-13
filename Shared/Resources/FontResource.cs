#if EXPORTFONTS
// Export the font to ensure it is visibility
using Shared.Resources;

[assembly: ExportFont("opensans-regular.ttf", Alias = "OpenSansRegular")]
[assembly: ExportFont("opensans-semibold.ttf", Alias = "OpenSansSemibold")]
[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = nameof(Material))]
#endif

namespace Shared.Resources;

/// <summary>
/// Provides a font description for loading a font stored as an embedded resource.
/// </summary>
public sealed class FontResource
{
    static FontResource()
    {
        List<FontResource> defaults = new List<FontResource>()
        {
            new ("opensans-regular.ttf", "OpenSansRegular"),
            new ("opensans-semibold.ttf", "OpenSansSemibold"),
            new ("materialdesignicons-webfont.ttf", nameof(Material)),
        };
        Defaults = defaults;
    }

    static public readonly IEnumerable<FontResource> Defaults;

    /// <summary>
    /// Loads the <see cref="FontResource"/> instances into a <see cref="IFontCollection"/>.
    /// </summary>
    /// <param name="fonts">The <see cref="IFontCollection"/> to populate.</param>
    /// <param name="fontResources">An <see cref="IEnumerable{FontResource}"/> for iterating the fonts to load.</param>
    public static void Load(IFontCollection fonts, IEnumerable<FontResource> fontResources)
    {
        foreach (FontResource desc in fontResources)
        {
            fonts.AddFont(desc.FileName, desc.Alias);
        }
    }

    /// <summary>
    /// Initializes a new instance of this class.
    /// </summary>
    /// <param name="fileName">The embedded resource's file name.</param>
    /// <param name="alias">The alias to use for the font. </param>
    public FontResource(string fileName, string alias)
    { 
        FileName = fileName;
        Alias = alias;
    }

    /// <summary>
    /// Gets the filename for the embedded resource font.
    /// </summary>
    public string FileName
    {
        get;
    }

    /// <summary>
    /// Gets the alias for the font.
    /// </summary>
    public string Alias
    {
        get;
    }
}
