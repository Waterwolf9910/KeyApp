using Microsoft.Extensions.Logging;
using Plugin.NFC;
using System.Runtime.InteropServices;

namespace NFCKeyApp;
public static class MauiProgram {
	public static MauiApp CreateMauiApp() {
		
		var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>();
		
		builder.ConfigureFonts(fonts => {
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			fonts.AddFont("Silkscreen-Regular.ttf", "Silkscreen");
			fonts.AddFont("Silkscreen-Bold.ttf", "SilkscreenBold");
        });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

}
