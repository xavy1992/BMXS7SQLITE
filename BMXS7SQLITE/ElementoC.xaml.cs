using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMXS7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ElementoC : ContentPage
    {
        public int IdSeleccionado;
        private SQLiteAsyncConnection con;
        IEnumerable<Cancha> rEliminar;
        IEnumerable<Cancha> rActualizar;




        public ElementoC(int Id, string NombreCancha, string Direccion, string Precio, string estado)
        {
            

            InitializeComponent();
            txtNombreC.Text = NombreCancha;
            txtDireccion.Text = Direccion;
            txtprecio.Text = Precio;
            txtestado.Text = estado;
            IdSeleccionado = Id;
        }
        public static IEnumerable<Cancha> Delete(SQLiteConnection db, int id)
        {

            return db.Query<Cancha>("DELETE FROM Cancha Where id =?", id);
        }

        public static IEnumerable<Cancha> Update(SQLiteConnection db, int Id, string NombreCancha, string Direccion, string Precio, string estado)

        {
            return db.Query<Cancha>("UPDATE cancha SET NombreCancha =?, Direccion=?, Precio =?, Estado =? where id = ?",  Id, NombreCancha, Direccion, Precio, estado);

        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {

                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Update(db, IdSeleccionado, txtNombreC.Text, txtDireccion.Text, txtprecio.Text, txtestado.Text);
                Navigation.PushAsync(new ConsultaCancha());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");

                
            }


        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Delete(db, IdSeleccionado);
                Navigation.PushAsync(new ConsultaCancha());
            }
            catch (Exception ex)
            {

                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }

        }
    }
}