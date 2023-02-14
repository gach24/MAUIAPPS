using NavigationDemo.Utilities;

namespace NavigationDemo.MVVM.Views;

public partial class FinalPage : ContentPage
{
	public FinalPage()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        NavUtilities.Examine(Navigation);
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        NavUtilities.InsertPage(Navigation);
    }
}