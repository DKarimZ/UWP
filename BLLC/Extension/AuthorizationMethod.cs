using BLLC.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace BLLC.Extension
{
	public class AuthorizationMethod
	{


        private readonly HttpClient _httpClient;
        private AuthorizationMethod() {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthentificationService.Getinstance().Token);

        }

      
        private static AuthorizationMethod _instance;
        private static object verrou = new object();
     
        public static AuthorizationMethod GetInstance()
        {
            if (_instance == null)
            {
                lock(verrou) {
                    if (_instance == null)
                    {
                        _instance = new AuthorizationMethod();
                    }
                }
            }
            return _instance;
        }

    }
}
