using ScreenBuilderMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace ScreenBuilderMVVM.ViewModels
{
	public class MainViewModel:ViewModelBase
	{
		public ObservableCollection<ToolBoxItem> Controls { get; set; } = new ObservableCollection<ToolBoxItem>();
		private ToolBoxItem selectedControl;

		public ToolBoxItem SelectedControl
		{
			get { return selectedControl; }
			set { selectedControl = value;OnPropertyChanged(); }
		}

		public MainViewModel()
		{
			Controls = new ObservableCollection<ToolBoxItem>();
			Controls.Add(new ToolBoxItem { Type = typeof(Button) });
			Controls.Add(new ToolBoxItem { Type = typeof(Label) });
			Controls.Add(new ToolBoxItem { Type = typeof(CheckBox) });
			Controls.Add(new ToolBoxItem { Type = typeof(TextBlock) });
			Controls.Add(new ToolBoxItem { Type = typeof(TextBox) });
			Controls.Add(new ToolBoxItem { Type = typeof(ComboBox) });
			Controls.Add(new ToolBoxItem { Type = typeof(Line) });
			Controls.Add(new ToolBoxItem { Type = typeof(Rectangle) });
		}
	}
}
