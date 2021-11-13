using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AndreaPerez
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viweInsertarB : ContentPage
    {
        public viweInsertarB()
        {
            InitializeComponent();
        }

        private async void btningresar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.100.245/moviles/post.php", "POST", parametros);

                await DisplayAlert("alerta","ingreso correcto","ok");
            }
            catch(Exception ex)
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