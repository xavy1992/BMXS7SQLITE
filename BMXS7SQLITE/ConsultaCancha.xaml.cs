using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace BMXS7SQLITE
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaCancha : ContentPage
    {
       
        private SQLiteAsyncConnection con;
        private ObservableCollection<Cancha> tcancha;
        public ConsultaCancha()
        {
            InitializeComponent();
            con = DependencyService.Get<DataBase>().GetConnection();
            ListarC();
        }

        public async void ListarC()
        {
            var resultadoo = await con.Table<Cancha>().ToListAsync();
            tcancha = new ObservableCollection<Cancha>(resultadoo);
            ListaCancha.ItemsSource = tcancha;
        }

        void OneSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Cancha)e.SelectedItem;
            var item = obj.Id.ToString();
            var Id = Convert.ToInt32(item);
            var NombreCancha = obj.NombreCancha.ToString();
            var Direccion = obj.Direccion.ToString();
            var Precio = obj.Precio.ToString();
            var Estado = obj.Estado.ToString();
            Navigation.PushAsync(new ElementoC(Id, NombreCancha, Direccion, Precio, Estado ));

        }
        private void btnRegresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}