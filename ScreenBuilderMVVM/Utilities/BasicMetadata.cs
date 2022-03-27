using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ScreenBuilderMVVM.Utilities
{
	public static class BasicMetadata
	{

        public static void Register()
        {
            GetButtonProperties(typeof(Button));

            GetTextBlockProperties(typeof(TextBlock));

            GetTextBoxProperties(typeof(TextBox));

            GetLabelProperties(typeof(Label));
            GetCheckBoxProperties(typeof(CheckBox));
            GetComboBoxProperties(typeof(ComboBox));
            GetLineProperties(typeof(Line));
            GetRectangleProperties(typeof(Rectangle));
            GetListBoxProperties(typeof(ListBox));
            GetBorderProperties(typeof(Border));

            Metadata.AddPopularControl(typeof(Button));
            Metadata.AddPopularControl(typeof(Border));
            Metadata.AddPopularControl(typeof(Canvas));
            Metadata.AddPopularControl(typeof(CheckBox));
            Metadata.AddPopularControl(typeof(ComboBox));
            Metadata.AddPopularControl(typeof(DataGrid));
            Metadata.AddPopularControl(typeof(DockPanel));
            Metadata.AddPopularControl(typeof(Expander));
            Metadata.AddPopularControl(typeof(Grid));
            Metadata.AddPopularControl(typeof(GroupBox));
            Metadata.AddPopularControl(typeof(Image));
            Metadata.AddPopularControl(typeof(InkCanvas));
            Metadata.AddPopularControl(typeof(Label));
            Metadata.AddPopularControl(typeof(ListBox));
            Metadata.AddPopularControl(typeof(ListView));
            Metadata.AddPopularControl(typeof(MediaElement));
            Metadata.AddPopularControl(typeof(Menu));
            Metadata.AddPopularControl(typeof(PasswordBox));
            Metadata.AddPopularControl(typeof(ProgressBar));
            Metadata.AddPopularControl(typeof(RadioButton));
            Metadata.AddPopularControl(typeof(RichTextBox));
            Metadata.AddPopularControl(typeof(StackPanel));
            Metadata.AddPopularControl(typeof(ScrollViewer));
            Metadata.AddPopularControl(typeof(Slider));
            Metadata.AddPopularControl(typeof(TabControl));
            Metadata.AddPopularControl(typeof(TextBlock));
            Metadata.AddPopularControl(typeof(TextBox));
            Metadata.AddPopularControl(typeof(TreeView));
            Metadata.AddPopularControl(typeof(ToolBar));
            Metadata.AddPopularControl(typeof(Viewbox));
            Metadata.AddPopularControl(typeof(Viewport3D));
            Metadata.AddPopularControl(typeof(WrapPanel));
            Metadata.AddPopularControl(typeof(Line));
            Metadata.AddPopularControl(typeof(Polyline));
            Metadata.AddPopularControl(typeof(Ellipse));
            Metadata.AddPopularControl(typeof(Rectangle));
            Metadata.AddPopularControl(typeof(Path));
        }

        private static void GetBorderProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, Border.BorderThicknessProperty, new Thickness(1));
            Metadata.AddDefaultPropertyValue(type, Border.BorderBrushProperty, new SolidColorBrush(Colors.Blue));
        }

        private static void GetListBoxProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, ListBox.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, ListBox.HeightProperty, 20.00);

        }

        private static void GetRectangleProperties(Type type)
        {

            Metadata.AddDefaultPropertyValue(type, Rectangle.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, Rectangle.HeightProperty, 20.00);
            Metadata.AddDefaultPropertyValue(type, Rectangle.FillProperty, new SolidColorBrush(Colors.Green));
            Metadata.AddDefaultPropertyValue(type, Rectangle.StrokeProperty, new SolidColorBrush(Colors.Red));
            Metadata.AddDefaultPropertyValue(type, Rectangle.StrokeThicknessProperty, 20.00);

        }

        private static void GetLineProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, Line.X1Property, 100.00);
            Metadata.AddDefaultPropertyValue(type, Line.X2Property, 20.00);
            Metadata.AddDefaultPropertyValue(type, Line.Y1Property, 200.00);
            Metadata.AddDefaultPropertyValue(type, Line.Y2Property, 30.00);
            Metadata.AddDefaultPropertyValue(type, Line.FillProperty, new SolidColorBrush(Colors.Black));
            Metadata.AddDefaultPropertyValue(type, Line.StrokeProperty, Brushes.Black);
            Metadata.AddDefaultPropertyValue(type, Line.StrokeThicknessProperty, 2d);
            Metadata.AddDefaultPropertyValue(type, Line.StretchProperty, Stretch.None);
        }

        private static void GetComboBoxProperties(Type type)
        {


            Metadata.AddDefaultPropertyValue(type, ComboBox.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, ComboBox.HeightProperty, 20.00);
        }

        private static void GetCheckBoxProperties(Type type)
        {


            Metadata.AddDefaultPropertyValue(type, CheckBox.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, CheckBox.HeightProperty, 20.00);
            Metadata.AddDefaultPropertyValue(type, CheckBox.ContentProperty, type.Name);

        }

        private static void GetLabelProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, Label.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, Label.HeightProperty, 20.00);
            Metadata.AddDefaultPropertyValue(type, CheckBox.ContentProperty, type.Name);
        }

        private static void GetTextBoxProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, TextBox.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, TextBox.HeightProperty, 20.00);
            Metadata.AddDefaultPropertyValue(type, TextBox.TextProperty, type.Name);

        }

        private static void GetTextBlockProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, TextBlock.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, TextBlock.HeightProperty, 20.00);
            Metadata.AddDefaultPropertyValue(type, TextBlock.TextProperty, type.Name);

        }

        private static void GetButtonProperties(Type type)
        {
            Metadata.AddDefaultPropertyValue(type, Button.WidthProperty, 100.00);
            Metadata.AddDefaultPropertyValue(type, Button.HeightProperty, 35.00);
            Metadata.AddDefaultPropertyValue(type, Button.ContentProperty, type.Name);
           
            Metadata.AddDefaultPropertyValue(type, Button.AllowDropProperty, true);

        }
    }
}
