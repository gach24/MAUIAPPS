namespace CodeQuotes
{
    public partial class MainPage : ContentPage
    {
        private List<string> quotes = new List<string>();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();
        }

        private void btnGenerateQuote_Clicked(object sender, EventArgs e)
        {
            // Generate and set new gradient
            Random rnd = new Random();
            var startColor = System.Drawing.Color.FromArgb(
                rnd.Next(0, 255),
                rnd.Next(0, 255),
                rnd.Next(0, 255));

            var endColor = System.Drawing.Color.FromArgb(
                rnd.Next(0, 255),
                rnd.Next(0, 255),
                rnd.Next(0, 255));

            var colors = ColorUtility.ColorControls.GetColorGradient(startColor, endColor, 6);

            float offset = .0f;
            var stops = new GradientStopCollection();
            foreach ( var color in colors )
            {
                stops.Add(new GradientStop(Color.FromArgb(color.Name), offset));
                offset += .2f;
            }

            var gradient = new LinearGradientBrush(stops, new Point(0, 0), new Point(1, 1));
            grdBackgroud.Background = gradient;

            // Set qoute to label
            int index = rnd.Next(quotes.Count);
            lblQuote.Text = quotes[index];

        }

        private async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() != -1) 
                quotes.Add(reader.ReadLine());
            
        }

    }
}