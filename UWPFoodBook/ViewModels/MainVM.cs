using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UWPFoodBook.ViewModels
{
	public class MainVM : ViewModelBase
	{

		private string _titre;

		public string Titre
		{
			get => _titre;
			set => Set(ref _titre, value);
		}

		private int _x ;

		public int X
		{
			get => _x;
			set => Set(ref _x, value);
		}

		private int _y ;

		public int Y
		{
			get => _y;
			set => Set(ref _y, value);
		}

		private int _result;

		public int Result
		{
			get => Calculate();
			set => Set(ref _result, value);
		}
		

		public int Calculate() => X + Y;

	}
}
