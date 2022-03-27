using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScreenBuilderMVVM.Models
{
	public class ToolBoxItem
	{
		public Type Type { get; set; }

		private object _instance;

		public object Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Activator.CreateInstance(Type);
				}
				return _instance;
			}
			
		}

		public string Name
		{
			get
			{
				return Type.Name;
			}
		}
		

	}
}
