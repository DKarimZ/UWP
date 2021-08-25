using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UWPFoodBook.Models
{
	public class ModelBase : INotifyPropertyChanged
	{

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));


		protected bool Set<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
		{
			if(Equals(storage, value))
			{
				return false;

			}

			storage = value;
			OnPropertyChanged(propertyName);
			return true;
	}
	}
}
