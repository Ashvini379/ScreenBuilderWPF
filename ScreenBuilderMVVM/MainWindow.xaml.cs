using ScreenBuilderMVVM.CustomControls;
using ScreenBuilderMVVM.Models;
using ScreenBuilderMVVM.Utilities;
using ScreenBuilderMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenBuilderMVVM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private double m_VerticalDistance = 0;
        private double m_HorizontalDistance = 0;
        private double left = 0;
        private double top = 0;
        private DragCanvas canvas;
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        
        public MainWindow()
		{
			InitializeComponent();
            this.DataContext = new MainViewModel();
            BasicMetadata.Register();
            m_VerticalDistance = 0;
            m_HorizontalDistance = 5.0;
            canvas = (DragCanvas)ControlContainer.FindName("ContainerCanvas");
           
        }

        private void lstControls_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var toolboxitem = e.AddedItems[0] as ToolBoxItem;
            
            var instance = Activator.CreateInstance(toolboxitem.Type);
            var uiElement = instance as UIElement;
            var properties =Metadata.GetDependencyProperties( toolboxitem.Type);
            var values = Metadata.GetDefaultPropertyValues(toolboxitem.Type);
            foreach (var property in properties)
            {
                var prop = property.GetValue(uiElement) as DependencyProperty;
                if (values.ContainsKey(prop))
                {                    
                    uiElement.SetValue(prop, values[prop]);
                }
                else if (prop == MarginProperty)
				{                    
                    uiElement.SetValue(prop,new Thickness(m_HorizontalDistance, m_VerticalDistance, 0, 0));
                }
            }

            TranslateTransform animatedTranslateTransform =
             new TranslateTransform(0, 0);

            //Animation using doubleanimation
            var transformName = "AnimatedTranslateTransform" + toolboxitem.Type.Name+RandomNumber(0,1000);
            this.RegisterName(transformName, animatedTranslateTransform);            
            DoubleAnimation dax = new DoubleAnimation(m_HorizontalDistance,
                new Duration(TimeSpan.FromMilliseconds(500)));
            dax.SpeedRatio = 0.4;
			if (m_HorizontalDistance > canvas.MinimumWidth)
				m_HorizontalDistance = 0;

			DoubleAnimation day = new DoubleAnimation(m_VerticalDistance,
                new Duration(TimeSpan.FromMilliseconds(500)));
            day.SpeedRatio = 0.4;

            m_VerticalDistance += 25.0;
			if (m_VerticalDistance > canvas.MinimumHeight)
			{
				m_VerticalDistance = 0;
				m_HorizontalDistance += 50.0;
			}

			animatedTranslateTransform.BeginAnimation(TranslateTransform.XProperty, dax);
            animatedTranslateTransform.BeginAnimation(TranslateTransform.YProperty, day);
            uiElement.RenderTransform = animatedTranslateTransform;
            
            left = new Random(1).Next(0, (int)canvas.ActualWidth);
            top = new Random(1).Next(0, (int)canvas.ActualHeight);

            canvas.Children.Add(uiElement);
            DragCanvas.SetLeft(uiElement, left);
            DragCanvas.SetTop(uiElement, top);


            var adorner = AdornerLayer.GetAdornerLayer(canvas);
            adorner.Add(new ResizeAdorner(uiElement));
        }
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
