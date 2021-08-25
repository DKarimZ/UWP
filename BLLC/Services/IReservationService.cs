using BO.DTO.Requests;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public interface IReservationService
	{

		Task<IEnumerable<Reservation>> GetAllReservations();

		Task<Reservation> GetReservationById(int IdReservation);

		Task<bool> CreateReservation(ReservationsFilterRequest rfr);

	}
}
