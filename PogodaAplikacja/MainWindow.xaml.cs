using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Controls;

namespace PogodaAplikacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        private DispatcherTimer _timer;

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly string WarszawaUrl = "https://api.open-meteo.com/v1/forecast?latitude=52.2298&longitude=21.0118&current=temperature_2m,relative_humidity_2m";

        private readonly string GdanskUrl = "https://api.open-meteo.com/v1/forecast?latitude=54.3523&longitude=18.6491&current=temperature_2m,relative_humidity_2m";
        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss");
            tokyoTime.Text = DateTime.Now.AddHours(8).ToString("HH:mm:ss");
            date.Text = DateTime.Now.ToString("dd.M.yyyy");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            _timer.Stop();

        }

        private async void Pogoda_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == PogodaWarszawa)
            {
                await LoadWeatherAsync(WarszawaUrl, clickedButton, 0);
            }
            else if (clickedButton == PogodaGdansk)
            {
                await LoadWeatherAsync(GdanskUrl, clickedButton, 0);
            }
        }

        private async Task LoadWeatherAsync(string url, Button clickedButton, int i)
        {

            StatusPobierania.Text = "Pobieranie danych...";
            clickedButton.IsEnabled = false;
            string json = await _httpClient.GetStringAsync(url);
        }
    }
    
  }