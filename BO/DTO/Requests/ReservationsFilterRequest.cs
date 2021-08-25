using BO.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BO.DTO.Requests
{
	public class ReservationsFilterRequest
	{

		public int? IdService { get; set; }

		public DateTime DateResevation { get; set; }

		public int? NbPersonne { get; set; }

		public bool Entree { get; set; }

		public bool Plat {get; set; }

		public bool Dessert {get; set; }

		public int? idClient { get; set; }

	}
}
