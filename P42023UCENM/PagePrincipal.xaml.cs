using P42023UCENM.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace P42023UCENM
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PagePrincipal : ContentPage
	{
		public PagePrincipal()
		{
			InitializeComponent();
		}

		private void btnprocesar_Clicked(object sender, EventArgs e)
		{
			var emple = new Empleado
			{
				id = 1,
				nombres = txtnombre.Text,
				apellidos = txtapellido.Text,
				foto = null
			};

			// Esto es para llamar una segunda pagina y pasarle parametro a una segunda pantalla
			var secondpage = new PageResultado();
			secondpage.BindingContext = emple; // Paso de parametros a la pantalla
			Navigation.PushAsync(secondpage);


		}
	}
}