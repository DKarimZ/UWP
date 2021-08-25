using BLLC.Services;
using BO.DTO.Requests;
using BO.DTO.Responses;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPFoodBook.Models;

namespace UWPFoodBook.ViewModels
{
	public class ServiceVM : ViewModelBase
	{

		private ServiceM _menuChoiceM;

		private readonly IRestaurationService _restaurationService;

		public ServiceVM(){
			_menuChoiceM = ServiceM.Instance;
			_menuChoiceM.PropertyChanged += _menuChoiceM_PropertyChanged;
		}
		private int _idService;

		public int IdService
		{
			get => _idService;
			set => Set(ref _idService, value);

		}


		private string _entreeMidi;
		public string EntreeMidi
		{
			get => _entreeMidi;
			set => Set(ref _entreeMidi, value);
		}

		private string _platMidi;
		public string PlatMidi
		{
			get => _platMidi;
			set => Set(ref _platMidi, value);
		}

		private string _dessertMidi;
		public string DessertMidi
		{
			get => _dessertMidi;
			set => Set(ref _dessertMidi, value);
		}

		private string _entreeSoir;
		public string EntreeSoir
		{
			get => _entreeSoir;
			set => Set(ref _entreeSoir, value);
		}

		private string _platSoir;
		public string PlatSoir
		{
			get => _platSoir;
			set => Set(ref _platSoir, value);
		}

		private string _dessertSoir;
		public string DessertSoir
		{
			get => _dessertSoir;
			set => Set(ref _dessertSoir, value);
		}

		private DateTimeOffset _currentDate;
		public DateTimeOffset CurrentDate
		{
			get => _currentDate;
			set => Set(ref _currentDate, value);
		}

		// Additionnal code to midi service

		private  bool _midi;

		public bool MIDI
		{
			get => _midi;
			set => Set(ref _midi, value);
		}


		// End of additional code

		//public void Refresh() {
			
		//	_menuChoiceM.LoadThePlatsByday(new ServicesFilterRequest() { date= CurrentDate.DateTime, midi= 1});
		//	// _menuChoiceM.LoadThePlatsBydaySoir(new PlatsFilterRequest() { date= CurrentDate.DateTime, midi= 0});
		//}

		public void Refresh2() {

			_menuChoiceM.LoadPlatsduService(new Service() { dateJourservice = CurrentDate.DateTime, Midi = MIDI });

		}

		//public void Reserve() {
		//	//_menuChoiceM.AddAReservation(new Reservation(
		//}

		private void _menuChoiceM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if(e.PropertyName == "plats"){
				EntreeMidi = _menuChoiceM.Plats[0].Nom;	
				PlatMidi = _menuChoiceM.Plats[1].Nom;
				DessertMidi = _menuChoiceM.Plats[2].Nom;
				EntreeSoir = _menuChoiceM.Plats[3].Nom;
				PlatSoir = _menuChoiceM.Plats[4].Nom;
				DessertSoir = _menuChoiceM.Plats[5].Nom;
				IdService = _menuChoiceM.Service.IdService;
			}
		}
	}
}
