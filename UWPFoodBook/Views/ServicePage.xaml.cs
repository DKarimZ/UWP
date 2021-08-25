using BO.DTO.Requests;
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
	public sealed partial class ServicePage : Page
	{

		private ServiceVM VM = new ServiceVM();

		private ReservationVM RVM = new ReservationVM();

		public ServicePage()
		{

			InitializeComponent();
			
		}

		private void ButtonLundi_Click(object sender, RoutedEventArgs e)
		{
			VM.Refresh2();	
		}

		private void ButtonReserver_Click(object sender, RoutedEventArgs e)
		{
			RVM.AjouterReservation();
		}

	}
}
