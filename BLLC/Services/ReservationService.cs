using BO.DTO.Requests;
using BO.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BLLC.Services
{
	public class ReservationService : IReservationService
	{
	

		public ReservationService()
		{
			
		}

		public async Task<IEnumerable<Reservation>> GetAllReservations()
		{
			if (AuthentificationService.Getinstance().IsLogged)
			{
				using (var _httpClient = AuthentificationService.Getinstance().HttpClient)
				{

					var reponse = await _httpClient.GetAsync($"reservations");

					if (reponse.IsSuccessStatusCode)
					{
						using (var stream = await reponse.Content.ReadAsStreamAsync())
						{
							List<Reservation> reservations = await JsonSerializer.DeserializeAsync<List<Reservation>>(stream,
								new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
							return reservations;
						}
					}
					else
					{
						return null;
					}
				}
			}

			return null;

		}


		public async Task<Reservation> GetReservationById(int IdReservation)
		{
			if (AuthentificationService.Getinstance().IsLogged)
			{

				using (var _httpClient = AuthentificationService.Getinstance().HttpClient)
				{



					var reponse = await _httpClient.GetAsync($"reservations/" + IdReservation);

					if (reponse.IsSuccessStatusCode)
					{
						using (var stream = await reponse.Content.ReadAsStreamAsync())
						{
							Reservation reservation = await JsonSerializer.DeserializeAsync<Reservation>(stream,
								new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
							return reservation;
						}
					}
					else
					{
						return null;
					}
				}
			}


			return null;

		}

		public async Task<bool> CreateReservation(ReservationsFilterRequest rfr)
		{
			if (AuthentificationService.Getinstance().IsLogged)
			{

				using (var _httpClient = AuthentificationService.Getinstance().HttpClient)
				{

					var reponse = await _httpClient.PostAsJsonAsync($"reservations", rfr);

					if (reponse.IsSuccessStatusCode)
					{

						using (var stream = await reponse.Content.ReadAsStreamAsync())
						{
							Reservation reservation = await JsonSerializer.DeserializeAsync<Reservation>(stream,
								new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

							return true;
						}
					}
					else
					{
						return false;
					}
				}
			}
			else
			{
				return false;
			}

		}

	}
}
