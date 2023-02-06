using DataBindingDemo.Models;

namespace DataBindingDemo
{
    public partial class BindingCodePage : ContentPage
    {

        public BindingCodePage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Person person = new Person
            {
                Name = "John",
                Phone = "9999",
                Address = "X Address"
            }; 

            Binding personBinding = new Binding();
            personBinding.Source = person;
            personBinding.Path = "Name";
            lblName.SetBinding(Label.TextProperty, personBinding);
        }
    }
}