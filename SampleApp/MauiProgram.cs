using Microsoft.Extensions.Logging;
using Shared.Resources;
using SampleApp.Resources;

namespace SampleApp
{
    public static class MauiProgram
    {
        static IEnumerable<FontResource> Fonts
        {
            get
            {
                return new List<FontResource>(FontResource.Defaults)
                {
                    new FontResource("fluentsystemicons-resizable.ttf", nameof(FluentUI))
                };
            }
        }
        
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    FontResource.Load(fonts, Fonts);
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
