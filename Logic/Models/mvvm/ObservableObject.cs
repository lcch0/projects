using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Logic.Models.mvvm
{
	public abstract class ObservableObject : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			PropertyChanged?.Invoke(sender, e);
		}

		public void RaisePropertyChanged<T>(object sender, Expression<Func<T>> propertyExpresssion)
		{
			var propertyName = PropertySupport.ExtractPropertyName(propertyExpresssion);
			RaisePropertyChanged(sender, propertyName);
		}

		protected void RaisePropertyChanged(object sender, string propertyName)
		{
			VerifyPropertyName(propertyName);
			OnPropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
		}

		/// <summary>
		/// Warns the developer if this Object does not have a public property with
		/// the specified name. This method does not exist in a Release build.
		/// </summary>
		[Conditional("DEBUG")]
		[DebuggerStepThrough]
		public void VerifyPropertyName(string propertyName)
		{
			// verify that the property name matches a real,  
			// public, instance property on this Object.
			if (TypeDescriptor.GetProperties(this)[propertyName] == null)
			{
				Debug.Fail("Invalid property name: " + propertyName);
			}
		}
	}
}
