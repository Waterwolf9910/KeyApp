using Plugin.NFC;
using System.Runtime.InteropServices;

namespace NFCKeyApp;

public partial class App : Application {

	public App() {
        if (!CrossNFC.Current.IsAvailable) {
#if IOS
			exit(0);
#else
			this.Quit();
#endif
        }
        InitializeComponent();

		MainPage = new AppShell();
	}
#if IOS
		[DllImport("__Internal", EntryPoint = "exit")]
		public static extern void exit(int status);
#endif
}
