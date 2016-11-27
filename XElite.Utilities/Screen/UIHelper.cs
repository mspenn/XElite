using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MicroSmadio.XElite.Utilities.Screen
{
    public class UIHelper
    {
        public static ResourceDictionary GetResource(string assemblyInfo, string pathFromRoot)
        {
            // Read resource dictionary
            ResourceDictionary rd = new ResourceDictionary();
            rd.Source = new Uri(String.Format(@"/{0};component/{1}", assemblyInfo, pathFromRoot), UriKind.Relative);
            return rd;
        }
        public static void ApplyUIStyle(ref FrameworkElement resElement, string stylePath, string styleName)
        {
            resElement.Resources.MergedDictionaries.Add(GetResource(resElement.GetType().Assembly.GetName().Name, stylePath));
            // Get style
            resElement.Style = resElement.FindResource(styleName) as Style;
        }
        public static void FindChildByName(DependencyObject relate, Type type, ref FrameworkElement resElement, string name = null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(relate); i++)
            {
                var el = VisualTreeHelper.GetChild(relate, i) as FrameworkElement;
                if (el == null) return;
                bool flag = name == null ? true : (el.Name == name ? true : false);
                if (el.GetType() == type && flag)
                {
                    resElement = el;
                    return;
                }
                else
                {
                    FindChildByName(el, type, ref resElement, name);
                }
            }
        }
    }
}
