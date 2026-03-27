namespace MauiTest
{
    public partial class MainPage : ContentPage
    {
        private readonly ViewModel viewModel = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private async void AddToList(object sender, EventArgs e)
        {
            if (viewModel.SelectedDate == null)
            {
                await ShowDialog("Kein Datum", "Kein Datum gewählt!");
                return;
            }
            string date = viewModel.SelectedDate.Value.ToString("dd.MM.yyyy");
            if (viewModel.Dates.Contains(date))
            {
                await ShowDialog("Datum vorhanden", "Datum " + date + " bereits vorhanden! ");
                return;
            }
            viewModel.Dates.Add(date);
        }

        private async Task ShowDialog(string title, string text)
        {
            bool answer = await DisplayAlertAsync(title, text, "OK", "Abbrechen");
        }

        private async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (viewModel.SelectedDate != null)
            {
                string? date = viewModel.SelectedText;
                if (date != null)
                {
                    await ShowDialog("Gewähltes Datum", "Du hast " + date + " aus der Liste gewählt! ");
                }
                return;
            }
        }
    }
}