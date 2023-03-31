namespace NFCKeyApp;

public partial class KeyListPage : ContentPage {

	protected TableView Table = new() {
        Intent = TableIntent.Data,
		Margin = new Thickness(10, 10),
        Root = new("Keys")
	};

    protected async Task UpdateTable() {
        await Task.Run(() => {
            TableSection section = new();
            var keys = KeyStore.Instance.GetData();
            int i = 0;
            foreach (var entry in keys) {
                ++i;
                KeyData key = entry.Value;
                ViewCell cell = new() {
                    View = new Label() {
                        VerticalOptions = LayoutOptions.Center,
                        Text = $"{i}. {key.Name}"
                    }
                };
                cell.Tapped += async (sender, e) => {
                    string selection = await DisplayActionSheet($"Delete: {key.Name}", "No", "Yes");
                    if (selection == "Yes") {
                        KeyStore.Instance.Remove(entry.Key);
                    }
                };
                section.Add(cell);
            }
            MainThread.BeginInvokeOnMainThread(() => {
                Refresher.IsRefreshing = false;
                Table.Root = new() {
                    new TableRoot("Keys") {
                        section
                    }
                };
            });
        });
    }
	public KeyListPage() {
		InitializeComponent(); 
		Page.Children.Add(Table);
        KeyStore.Instance.StoreEdited += async () => {
            Refresher.IsEnabled = false;
            await UpdateTable();
            Refresher.IsEnabled = true;
        };
        Refresher.Command = new Command(() => {
            _ = UpdateTable();
        });
        _ = UpdateTable();
    }
}