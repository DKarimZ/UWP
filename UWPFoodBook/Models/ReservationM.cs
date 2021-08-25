using BLLC.Services;
using BO.DTO.Requests;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UWPFoodBook.Models
{
	class ReservationM : ModelBase
	{
		IReservationService _reservationService = new ReservationService();


		[JsonConstructor]

		public ReservationM() { }

		private Service _service;

		public Service Service
		{
			get => _service;
			set => Set(ref _service, value);
		}

		private int? _idService;

		public int? IdService
		{
			get => _idService;
			set => Set(ref _idService, value);
		}

		private DateTime _dateReservation;

		public DateTime DateReservation{

			get => _dateReservation;
			set => Set(ref _dateReservation, value);

		}

		private int? _nbPersonnes;

		public int? NbPersonnes{
			get => _nbPersonnes;
			set => Set(ref _nbPersonnes, value);


		}

		private Boolean _entree;

		public Boolean Entree{
			get => _entree;
			set => Set(ref _entree, value);
		}

		private Boolean _plat;

		public Boolean Plat
		{
			get => _plat;
			set => Set(ref _plat, value);
		}

		private Boolean _dessert;

		public Boolean Dessert
		{
			get => _dessert;
			set => Set(ref _dessert, value);
		}

		private int? _idClient;

		public int? IdClient{
			get => _idClient;
			set => Set(ref _idClient, value);

		}

		public async Task<bool> CreateTheReservation(ReservationsFilterRequest rfr)
		{
			
			bool success = await _reservationService.CreateReservation(rfr);

			IdService = rfr.IdService;
			DateReservation = rfr.DateResevation;
			NbPersonnes = rfr.NbPersonne;
			Entree = rfr.Entree;
			Plat = rfr.Plat;
			Dessert = rfr.Dessert;
			IdClient = rfr.idClient;

			return success;


		}

		//public async Task<bool> CreateTheReservation(Reservation reservation)
		//{

		//	bool success = await _reservationService.CreateReservation(reservation);

		//	IdService = reservation.IdService;
		//	DateReservation = rfr.DateResevation;
		//	NbPersonnes = rfr.NbPersonne;
		//	Entree = rfr.Entree;
		//	Plat = rfr.Plat;
		//	Dessert = rfr.Dessert;
		//	IdClient = rfr.idClient;

		//	return success;


		//}
	}
}
