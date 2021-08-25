using BLLC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPFoodBook.Models;

namespace UWPFoodBook.ViewModels
{
	public class LoginVM : ViewModelBase
	{
		private LoginM _loginM;

		public LoginVM()
		{
			_loginM = LoginM.Instance;

			_login = _loginM.Login;
			_motDePasse = _loginM.MotDePasse;

		}


		private string _login;
		public string Login
		{
			get => _login;
			set => Set(ref _login, value);
		}


		private string _motDePasse;

		public string MotDePasse
		{
			get => _motDePasse;
			set => Set(ref _motDePasse, value);
		}

		public void SaveCommand()
		{
			_loginM.Login = Login;
			_loginM.MotDePasse = MotDePasse;
			_loginM.Save();
		}



		public async Task<bool> LoginMethod()
		{

			var result = await AuthentificationService.Getinstance().SignIn(_loginM.Login, _loginM.MotDePasse);

			return result;


		}
	}
}
