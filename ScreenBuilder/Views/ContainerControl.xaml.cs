﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenBuilder.Views
{
	/// <summary>
	/// Interaction logic for ContainerControl.xaml
	/// </summary>
	public partial class ContainerControl : UserControl
	{		
		public ContainerControl()
		{
			InitializeComponent();
		}

		private void ContainerCanvas_ScrollChanged(object sender, ScrollChangedEventArgs e)
		{
			var canvas = sender as Canvas;
			
			//canvas.SetValue(ScrollViewer.VerticalScrollBarVisibilityProperty,ScrollBarVisibility.Visible);
		}
	}


}
