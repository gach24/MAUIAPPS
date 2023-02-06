using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;

namespace FodyDemo
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }

        public ICommand AddCommand =>
            new Command(() => Result = Number1 + Number2);
    }
}
