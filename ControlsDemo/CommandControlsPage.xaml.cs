namespace ControlsDemo;

public partial class CommandControlsPage : ContentPage
{
	public CommandControlsPage()
	{
		InitializeComponent();
	}

    private void btnTest_Clicked(object sender, EventArgs e)
    {
		DisplayAlert("Text", "This is a demo", "Ok");
    }

    private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        DisplayAlert("RadioButton", $"Changed: {e.Value}", "Ok");
    }

    private void searchControl_SearchButtonPressed(object sender, EventArgs e)
    {
        DisplayAlert("Searching", $"Searching: {searchControl.Text}", "Ok");
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {
        DisplayAlert("SwipeView", $"Element tabbed", "Ok");
    }
}