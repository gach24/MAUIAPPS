using DataBindingDemo.Models;
using System.Collections.Specialized;
using System.ComponentModel;

namespace DataBindingDemo;

public partial class MainPage : ContentPage
{
    private Person person;
    public MainPage()
	{
		InitializeComponent();
        person = new Person
        {
            Name = "John",
            Phone = "9999",
            Address = "X Address"
        };

        BindingContext = person;
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        /*
        person.Name = "Peter";
        person.Phone = "0000";
        person.Address = "New Address";
        */
        person = new Person
        {
            Name = "Peter",
            Phone = "0000",
            Address = "New Address",
        };
    }

}