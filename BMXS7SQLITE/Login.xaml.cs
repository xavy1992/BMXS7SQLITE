using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace BMXS7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage

    {
        private SQLiteAsyncConnection con;
        public Login()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();

        }
        public static IEnumerable<Estudiante> Select_Where(SQLiteConnection db, string usuario, string contasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante where Usuario=? and Contrasena=?", usuario, contasena );
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {

            try
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Select_Where(db, txtUsuario.Text, txtContrasena.Text);
                if (resultado.Count() > 0)
                {
                    Navigation.PushAsync(new ConsultaRegistro());
                }
                else
                {
                    DisplayAlert("Alerta", "Usuario o contraseña Incorrecto ", "Cerrar");
                }
            }
            catch ( Exception ex)
            {

                DisplayAlert("Alerta", ex.Message,"Cerrar");
            }
        }

        private void btnRegistar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }
    }
}