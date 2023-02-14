using NavigationDemo.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationDemo.Utilities
{
    public static class NavUtilities
    {
        public static void Examine(INavigation navitation)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var page in navitation.NavigationStack)
            {
                builder.AppendLine(page.GetType().Name);
            }
            builder.AppendLine("--------------------");
            Debug.WriteLine(builder.ToString());
        }

        public static void InsertPage(INavigation navigation)
        {
            var secondPage = navigation.NavigationStack.ElementAtOrDefault(1);
            if (secondPage != null)
            {
                navigation.InsertPageBefore(new CoolPage(), secondPage);
            }
        }

        public static void DeletePage(INavigation navigation, string name)
        {
            var pageToDelete = navigation
                                .NavigationStack
                                .FirstOrDefault(page => page.GetType().Name == name);
            if (pageToDelete != null)
            {
                navigation.RemovePage(pageToDelete);
            }
        }
    }
}
