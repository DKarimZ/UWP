﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public class ReservationService
	{
		private readonly HttpClient _httpClient;

		public ReservationService()
		{
			_httpClient = new HttpClient();
			_httpClient.BaseAddress = new Uri("https://localhost:5001/api/");
		}

		//To continue

	}
}
