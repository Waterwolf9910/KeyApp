namespace NFCKeyApp;

public partial class LicensesPage : ContentPage {
	public LicensesPage() {
		InitializeComponent();
		MainThread.BeginInvokeOnMainThread(WriteLicenses);
	}

	async void WriteLicenses() {
        string MainLicense = new StreamReader(await FileSystem.OpenAppPackageFileAsync("Licenses/Main")).ReadToEnd();
		string SilkscreenLicense = new StreamReader(await FileSystem.OpenAppPackageFileAsync("Licenses/Silkscreen")).ReadToEnd();
		string sep = "";
		int i = ((int)Page.Width);
		while (i > 0) {
			--i;
			sep += "-";
		}
		Page.Children.Add(new Label() {
			Text = MainLicense,
			VerticalOptions = LayoutOptions.Center,
			HorizontalOptions = LayoutOptions.Center,
		});
		Page.Children.Add(new Label() {
			Text = "-------------------------"
		});
		
        Page.Children.Add(new Label() {
            Text = SilkscreenLicense,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center,
        });
    }
}