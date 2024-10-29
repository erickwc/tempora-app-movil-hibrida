using Microsoft.Extensions.Logging;
using Tempora.MAUIApp.Models;
using Tempora.MAUIApp.Services;

namespace Tempora.MAUIApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddScoped(http => new HttpClient{
                BaseAddress = new Uri("http://www.tempora.somee.com/")
            });

            builder.Services.AddScoped<UsuarioService>();
            builder.Services.AddScoped<DiaService>();
            builder.Services.AddScoped<PeriodoService>();
            builder.Services.AddScoped<EstadoService>();

            return builder.Build();
        }
    }
}
