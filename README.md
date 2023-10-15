# FontResource
Example class for loading Maui fonts from various assemblies.

I created this for the case where I have the a shared assembly for the use case where I have a set of common fonts used across all applications and one or more fonts needed by a specific application.
The goal is provide an easy method for merging the definitions for the 'common' fonts with the application-specific fonts and registering them as a set.

# Shared\Resources\FontResource.cs
This class is provides a simple declaration of font file and alias and resides in the shared assembly.  The set of fonts in the shared assembly is published via a static IEnumerable<FontResource> on the FontResource class.
When an application needs additional fonts, it merges Default with it's one FontResource definintions and passes the merged IEnumerable<FontResource> to FontResource.Load

# SampleApp\MauiProgram.cs
This illustrates an application that need to register an additional font at builder.ConfigureFonts time.

MauiProgram.Fonts defines a static IEnumerable<FontResource> property. The implementation merges FontResource.Default with it's own font(s) and returns the combined set.
The property is consumed by MauiProgram.CreateMauiApp as follows:

...
public static MauiApp CreateMauiApp()
{
    var builder = MauiApp.CreateBuilder();
    builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
            FontResource.Load(fonts, Fonts);
        });
}
...

