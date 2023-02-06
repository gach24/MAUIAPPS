namespace ControlsDemo;

public partial class InputControlsPage : ContentPage
{
	public InputControlsPage()
	{
		InitializeComponent();
	}

    private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		lblSlider.Text = e.NewValue.ToString();
    }

    private void stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        lblSlider.Text = e.NewValue.ToString();
    }
}