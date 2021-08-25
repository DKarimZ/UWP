using BLLC.Services;
using BO.DTO.Requests;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPFoodBook.Models
{
	class ServiceM : ModelBase
	{

		IRestaurationService _restaurationService = new RestaurationService();

		private static ServiceM _instance;

		private static object _verrou = new object();

		public static ServiceM Instance
		{
			get
			{
				if(_instance == null ){
					
					lock(_verrou){

						if(_instance == null){

							_instance = new ServiceM();
						}

					}

				}
				return _instance;

			}
		}

		private ServiceM() { }

		private Service _service;

		public Service Service
		{
			get => _service;
			set => Set(ref _service, value);

		}

		private ObservableCollection<Plat> _plats;

		public ObservableCollection<Plat> Plats
		{
			get => _plats;
			set => Set(ref _plats, value);
		}

		private DateTime _date;

		public DateTime Date
		{
			get => _date;
			set => Set(ref _date, value);
		}

		private Boolean _midi;

		public Boolean Midi
		{
			get => _midi;
			set => Set(ref _midi, value);
		}

		//public async Task LoadThePlatsByday(ServicesFilterRequest pfr)
		//{
		//	Task<IEnumerable<Plat>> platTask = _restaurationService.GetAllPlatsByDateAndService(pfr);
		//	Plats = new ObservableCollection<Plat>(await platTask);
		//	Date = pfr.date.GetValueOrDefault();
		//	Midi = pfr.midi.GetValueOrDefault();
		//}

		public async Task LoadPlatsduService(Service service)
		{
			Task<Service> serviceTask =  _restaurationService.GetServiceByDateAndMidi(service.dateJourservice, service.Midi);
			Service serv = await serviceTask;
			Date =service.dateJourservice;
			Midi = service.Midi;
			Service = service;
			Service.IdService = serv.IdService;
			Plats = new ObservableCollection<Plat>(serv.Plats);

		}

		//public async Task LoadThePlatsBydaySoir(PlatsFilterRequest pfr)
		//{
		//	Task<IEnumerable<Plat>> platTask = _restaurationService.GetAllPlatsByDateAndService(pfr);
		//	Plats = new ObservableCollection<Plat>(await platTask);
		//	Date = pfr.date.GetValueOrDefault();
		//	Midi = pfr.midi.GetValueOrDefault();
		//}
	}
}
