using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndreaPerez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewActualizar : ContentPage
    {     

        public viewActualizar(int c, string n, string a, int e)
        {
            InitializeComponent();
            txtCodigo.Text = c.ToString();
            txtNombre.Text = n;
            txtApellido.Text = a;
            txtEdad.Text = e.ToString();
        }

        private async void btnactualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection(); 

                cliente.UploadValues("http://192.168.100.245/moviles/post.php?codigo="+txtCodigo.Text+
                    "&nombre="+txtNombre.Text+"&apellido="+txtApellido.Text+"&edad="+txtEdad.Text, "PUT", parametros);

                await DisplayAlert("alerta", "datos actualizados", "ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("alerta", ex.Message, "ok");
            }
        }

        private async void btnregresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }
    }
}