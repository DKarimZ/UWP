using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPFoodBook.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace UWPFoodBook.Views
{
	public sealed partial class LoginPage : Page
	{

		private LoginVM VM = new LoginVM();

		public LoginPage()
		{
			InitializeComponent();
		}


		private async void Button_Click(object sender, RoutedEventArgs e)
		{
			VM.SaveCommand();
			bool r = await VM.LoginMethod();
			

			if(r) {
				Frame.Navigate(typeof(ServicePage));
			}

			else
			{

				Console.WriteLine("ca marche pas!");
			}
		}

	}
}
