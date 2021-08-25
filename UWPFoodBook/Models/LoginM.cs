using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Windows.Storage;

namespace UWPFoodBook.Models
{
	class LoginM : ModelBase
	{

		private static LoginM _instance;

		private static readonly object Verrou = new object();


		public static LoginM Instance
		{
			get{

				lock (Verrou)
				{
					if(_instance == null)
					{
						_instance = Load();
					}

					return _instance;
			
				}
		
				}

	
		}


		[JsonConstructor]

		public LoginM(){ }

		private string _login;

		public string Login
		{
			get => _login;
			set => Set(ref _login, value);
		}


		private string _motdepasse;

		public string MotDePasse
		{
			get => _motdepasse;
			set => Set(ref _motdepasse, value);
		}

		public bool IsEmpty
		{
			get => string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(MotDePasse);
		}


		public void Save()
		{
			ApplicationData.Current.LocalSettings.Values["Logs"] = JsonSerializer.Serialize(this);

		}

		public static LoginM Load()
		{
			try
			{
				return JsonSerializer.Deserialize<LoginM>(
					ApplicationData.Current.LocalSettings.Values["Logs"] as string);
			}
			catch (Exception e)
			{
				return new LoginM();
			}


		}







	} }
