using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using BO.DTO.Requests;
using BO.DTO.Responses;

namespace BLLC.Services
{
	public class AuthentificationService
	{

		private static AuthentificationService instance;
		

		private static object verrou = new object();

		public Boolean IsLogged { get; private set; }

		public String Token { get; private set; }

		private AuthentificationService()
		{
			IsLogged = false;
			Token = null;
		}

		public static AuthentificationService Getinstance()
		{
			lock (verrou)
			{
				if (instance == null)
				{
					instance = new AuthentificationService();

				}

			}
			return instance;
		}
		
		public async Task<bool> SignIn(string username, string password)
		{
#if DEBUG
			var handler = new HttpClientHandler();
			handler.ClientCertificateOptions = ClientCertificateOption.Manual;
			handler.ServerCertificateCustomValidationCallback =
				(httpRequestMessage, cert, cetChain, policyErrors) =>
				{
					return true;
				};
			var _httpClient = new HttpClient(handler);
#else
			var _httpClient = new HttpClient();
#endif

			var loginrequest = new LoginRequest()
			{
				Username = username,
				Password = password

			};

			_httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/");

			try
			{
				var httpresponse = await _httpClient.PostAsJsonAsync("account/login", loginrequest);

				if (httpresponse.IsSuccessStatusCode)
				{
					var loginresponse = await httpresponse.Content.ReadFromJsonAsync<LoginResponse>();
					IsLogged = true;
					Token = loginresponse.AccessToken;
					return true;

				}

				return false;
			}
			catch (Exception exception)
			{
				return false;
			}

			

		}

		public HttpClient HttpClient {
		
			get {
				// BYPASS SSL Verification self signed
				HttpClientHandler handler = new HttpClientHandler()
				{
					ClientCertificateOptions = ClientCertificateOption.Manual,
					ServerCertificateCustomValidationCallback = delegate { return true; }
				};

				//END

				var _httpClient = new HttpClient(handler);
				_httpClient.BaseAddress = new Uri("https://localhost:5001/api/v1/");

				_httpClient.DefaultRequestHeaders.Authorization =
					new AuthenticationHeaderValue("Bearer", Token);

				return _httpClient;


			}
		}
	}
}
