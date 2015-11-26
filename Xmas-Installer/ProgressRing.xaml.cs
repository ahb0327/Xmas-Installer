using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Xmas_Installer
{
	/// <summary>
	/// ProgressRing.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class ProgressRing : UserControl
	{
		private int _value		= 0;
		private bool _isButton	= true;

		public ProgressRing()
		{
			InitializeComponent();
		}

		public int Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;

				if (!IsButton)
					tbpercent.Text = value.ToString() + "%";

				DoubleAnimation animation = new DoubleAnimation();
				animation.To = value * 3.6;
				animation.BeginTime = TimeSpan.FromMilliseconds(0);
				animation.Duration = TimeSpan.FromSeconds(1);

				CubicEase cubicEase = new CubicEase();
				cubicEase.EasingMode = EasingMode.EaseOut;

				animation.EasingFunction = cubicEase;

				Storyboard.SetTarget(animation, ForeGroundRing);
				Storyboard.SetTargetProperty(animation, new PropertyPath(Microsoft.Expression.Shapes.Arc.EndAngleProperty));

				Storyboard storyboard = new Storyboard();
				storyboard.Children.Add(animation);
				storyboard.Begin();
			}
		}

		public bool IsButton
		{
			get; set;
		}

		private void OnMouseEnter(object sender, MouseEventArgs e)
		{

		}

		private void OnMouseLeave(object sender, MouseEventArgs e)
		{

		}
	}
}
