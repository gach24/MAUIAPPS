using DataBindingDemo.Models;

namespace DataBindingDemo;

public partial class BindingContextPage : ContentPage
{
	public BindingContextPage()
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

        BindingContext = person;
        /*
        lblName.BindingContext = person;
        lblName.SetBinding(Label.TextProperty, "Name");
        */
    }
}