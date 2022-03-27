using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ScreenBuilder
{
	public partial class ControlContainers : ContentControl, INotifyPropertyChanged
	{

		static ControlContainers()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ControlContainers), new FrameworkPropertyMetadata(typeof(ControlContainers)));
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged(string propertyName)
		{
			var ev = PropertyChanged;
			if (ev != null)
				ev(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
