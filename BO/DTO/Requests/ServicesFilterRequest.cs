using System;
using System.Collections.Generic;
using System.Text;

namespace BO.DTO.Requests
{
	public class ServicesFilterRequest : PageRequest
	{
		public DateTime? date {get; set;}
		public int? midi { get; set;}
	}
}
