using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace BMXS7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            var datos = new Estudiante { Nombre = txtNombre.Text, Usuario= txtUsuario.Text, Contrasena = txtContrasena.Text};
            con.InsertAsync(datos);
            txtNombre.Text = "";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
            Navigation.PushAsync(new Login());

            
        }
    }
}