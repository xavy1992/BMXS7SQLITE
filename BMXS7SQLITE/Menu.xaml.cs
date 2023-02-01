using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMXS7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        private SQLiteAsyncConnection con;
        public Menu()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
        }

        private void btnRegistar_Clicked(object sender, EventArgs e)
        {
            var datos = new Cancha { NombreCancha = txtNombreC.Text, Direccion = txtDireccion.Text, Precio = txtprecio.Text, Estado = txtestado.Text };
            con.InsertAsync(datos);
            txtNombreC.Text = "";
            txtDireccion.Text = "";
            txtprecio.Text = "";
            txtestado.Text = "";
            Navigation.PushAsync(new ConsultaCancha());
        }
    }
}