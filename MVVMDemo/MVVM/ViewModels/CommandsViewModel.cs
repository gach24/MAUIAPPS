using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVMDemo.MVVM.ViewModels
{
    public class CommandsViewModel
    {
        // public ICommand ClickCommand { get; }
        public CommandsViewModel() 
        { 
            // ClickCommand = new Command(() => App.Current.MainPage.DisplayAlert("Title", "message", "ok"));
        }

        /*
        public ICommand ClickCommand =>
            new Command(Alert);

        public void Alert()
        {
            App.Current.MainPage.DisplayAlert("Title", "message", "ok");
        }
        */

        public ICommand ClickCommand =>
            new Command(() => App.Current.MainPage.DisplayAlert("Title", "message", "ok"));
        
        public ICommand SearchCommand => new Command((s) =>
        {
            // var data = SearchTerm;
            var data = s;
        });
        public string SearchTerm { get; set; }
    }
}
