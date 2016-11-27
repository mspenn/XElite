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

namespace MicroSmadio.XElite.User
{
    /// <summary>
    /// Interaction logic for LoadingControl.xaml
    /// </summary>
    public partial class LoadingIndicator : UserControl
    {
        #region Properties
        public Brush Color
        {
            get 
            {
                Brush c = (Brush)GetValue(ColorProperty);
                return Brushes.Black;
            }
            set { SetValue(ColorProperty, value); }
        }

        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty ColorProperty =
    DependencyProperty.Register("Color", typeof(Brush), typeof(LoadingIndicator), new PropertyMetadata(null));
        #endregion

        private Storyboard trans;

        public LoadingIndicator()
        {
            InitializeComponent();
            trans = Resources["Trans"] as Storyboard;
            this.Loaded += ((sender, e) =>
            {
                Active();
            });
        }

        public async void Active()
        {
            el.BeginStoryboard(trans);
            await Task.Delay(170);
            el2.BeginStoryboard(trans);
            await Task.Delay(170);
            el3.BeginStoryboard(trans);
            await Task.Delay(170);
            el4.BeginStoryboard(trans);
            await Task.Delay(170);
            el5.BeginStoryboard(trans);
            await Task.Delay(170);
            el6.BeginStoryboard(trans);
        }

        public void Stop()
        {
            trans.Stop(el);
            trans.Stop(el2);
            trans.Stop(el3);
            trans.Stop(el4);
            trans.Stop(el5);
            trans.Stop(el6);
        }
    }
}