using BLLC.Services;
using BO.DTO.Requests;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPFoodBook.Models;
using Windows.UI.Xaml.Controls;

namespace UWPFoodBook.ViewModels
{
	public class ReservationVM : ViewModelBase
	{
		private ReservationVM _reservationVM;

		private ServiceVM _serviceVM ;

		private ServiceM _serviceM;

		

		private readonly IRestaurationService _restaurationService;

		public ReservationVM()
		{
			var menuChoiceM = ServiceM.Instance;

				menuChoiceM.PropertyChanged += _menuChoiceM_PropertyChanged;
		//	_serviceM.PropertyChanged += _menuChoiceM_PropertyChanged;

		}


		private int? _idService;

		public int? IdService
		{
			get => _idService;
			set => Set(ref _idService, value);
		}

		private DateTime _dateReservation;

		public DateTime DateReservation
		{

			get => _dateReservation;
			set => Set(ref _dateReservation, value);

		}

		private int _nbPersonnes;

		public int NbPersonnes
		{
			get => _nbPersonnes;
			set => Set(ref _nbPersonnes, value);


		}

		private Boolean _entreeMidi;

		public Boolean EntreeMidi
		{
			get => _entreeMidi;
			set => Set(ref _entreeMidi, value);
		}

		private Boolean _platMidi;

		public Boolean PlatMidi
		{
			get => _platMidi;
			set => Set(ref _platMidi, value);
		}

		private Boolean _dessertMidi;

		public Boolean DessertMidi
		{
			get => _dessertMidi;
			set => Set(ref _dessertMidi, value);
		}

		private int? _idClient;

		public int? IdClient
		{
			get => _idClient;
			set => Set(ref _idClient, value);

		}



		private void _menuChoiceM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "Plats")
			{
				EntreeMidi = (ServiceM.Instance.Plats[0].typePlat.IdTypePlat == 1);
				PlatMidi = (ServiceM.Instance.Plats[1].typePlat.IdTypePlat == 2);
				DessertMidi = (ServiceM.Instance.Plats[2].typePlat.IdTypePlat == 3);
				IdService = (ServiceM.Instance.Service.IdService);
			}
		}

		public async void AjouterReservation(){
			//Ajouter controle de variables

			var reservationM = new ReservationM();
			ReservationsFilterRequest rfr = new ReservationsFilterRequest();

			rfr.IdService = IdService;
			rfr.DateResevation = ServiceM.Instance.Date;
			rfr.NbPersonne = NbPersonnes;
			rfr.Entree = EntreeMidi;
			rfr.Plat = PlatMidi;
			rfr.Dessert = DessertMidi;

			//reservationM.IdService = ServiceM.Instance.Service.IdService;
			//reservationM.DateReservation = DateTime.Now;
			//reservationM.NbPersonnes = Convert.ToInt16(NbPersonnes);
			//reservationM.Entree = EntreeMidi;
			//reservationM.Plat = PlatMidi;
			//reservationM.Dessert = DessertMidi;
			//reservationM.IdClient = 3;



			//var reservationM = new ReservationM();
			
			

			bool success = await reservationM.CreateTheReservation(rfr);

			if(success){

				ContentDialog contentDialog = new ContentDialog()
				{
					Title = "Cool",
					Content = "Reservation réussie",
					CloseButtonText = "Ok"
				};
				await contentDialog.ShowAsync();
			}

			else{
				ContentDialog contentDialog = new ContentDialog()
				{
					Title = "oh no",
					Content = "Ca marche po :(",
					CloseButtonText = "Ok"
				};
			await contentDialog.ShowAsync();
		}
		}

	}
}
