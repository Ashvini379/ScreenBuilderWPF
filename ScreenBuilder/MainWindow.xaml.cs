using ScreenBuilder.CustomControls;
using ScreenBuilder.Utilities;
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
//using ScreenBuilder.Views;

namespace ScreenBuilder
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        /// <summary>
        /// Vertical position for animation
        /// </summary>
        private double m_VerticalDistance = 0;

        /// <summary>
        /// horizontal position for animation
        /// </summary>
        private double m_HorizontalDistance = 0;

        /// <summary>
        /// Left of Control to be added on Container
        /// </summary>
        private double left = 0;
        /// <summary>
        /// Top of Control to be added on Container
        /// </summary>
        private double top=0;

        /// <summary>
        /// Canvas on which control to be added
        /// </summary>
        private DragCanvas canvas;
        /// <summary>
        /// Random number for animation transform
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// lock to generate random number
        /// </summary>
        private static readonly object syncLock = new object();


        private readonly Dictionary<UIElement, List<Adorner>> _controlToAdornersMap;



        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
		{
			InitializeComponent();
            BasicMetadata.Register();
            m_VerticalDistance = 0;
            m_HorizontalDistance = 5.0;
            canvas = (DragCanvas)ControlContainer.FindName("ContainerCanvas");
            _controlToAdornersMap = new Dictionary<UIElement, List<Adorner>>();
        }

        /// <summary>
        /// Tool box item selection change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            m_VerticalDistance += 50.0;
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

            

            //uiElement.MouseLeave += OnMyControlMouseEnterOrLeave;
            AddAdorners(uiElement);
            //var adorner = AdornerLayer.GetAdornerLayer(canvas);
            //adorner.Add(new ResizeAdorner(uiElement));

            uiElement.MouseEnter += (sender, e) =>
            {
                AdornerLayer.GetAdornerLayer(uiElement).Visibility = Visibility.Visible;
            };
        }

        private void AddAdorners(UIElement control)
        {
            var myAdorner = new ResizeAdorner(control);
           
            var adornerLayer = AdornerLayer.GetAdornerLayer(control);
            adornerLayer.Add(myAdorner);

            _controlToAdornersMap[control] = new List<Adorner> { myAdorner };
        }

        

        private void OnMyAdornerMouseEnterOrLeave(object sender, MouseEventArgs e)
        {
            var adorner = (Adorner)sender;
            HitTestAndSetAdornersVisibility((UIElement)adorner.AdornedElement, e);
        }

        private void HitTestAndSetAdornersVisibility(UIElement control, MouseEventArgs e)
        {
            var adorners = _controlToAdornersMap[control];
            var hitTestSubjects = new List<UIElement> { control }.Concat(adorners);
            var hit = hitTestSubjects.Any(i => VisualTreeHelper.HitTest(i, e.GetPosition(i)) != null);

            SetAdornersVisibility(adorners, hit ? Visibility.Visible : Visibility.Collapsed);
        }

        private static void SetAdornersVisibility(IEnumerable<Adorner> adorners, Visibility visibility)
        {
            if (adorners != null)
                foreach (var adorner in adorners)
                    adorner.Visibility = visibility;
        }
        /// <summary>
        /// Generate random number
        /// </summary>
        /// <param name="min">min value</param>
        /// <param name="max"> max value</param>
        /// <returns></returns>
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
    }
}
