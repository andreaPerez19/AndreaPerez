using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AndreaPerez
{
    public partial class MainPage : ContentPage
    {
        private const string Url = "http://192.168.100.245/moviles/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<AndreaPerez.Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            get();
        }

        private async void get()
        {
            var content = await client.GetStringAsync(Url);
            List<AndreaPerez.Datos> post = JsonConvert.DeserializeObject<List<AndreaPerez.Datos>>(content);
            _post = new ObservableCollection<AndreaPerez.Datos>(post);

            MyListView.ItemsSource = _post;

        }

        private async void btnGet_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new viweInsertarB());

        }

        private async void btnPost_Clicked(object sender, EventArgs e)
        {
            
        }

        private void btnDelete_Clicked(object sender, EventArgs e)
        {

        }
    }
}
