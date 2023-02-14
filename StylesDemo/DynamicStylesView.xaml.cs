namespace StylesDemo;

public partial class DynamicStylesView : ContentPage
{
	public DynamicStylesView()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Application.Current.Resources.TryGetValue("SpecialButton", out var retVal);

        // Resources["dynamicStyle"] = Resources["greenStyle"];
        Resources["dynamicStyle"] = (Style)retVal;

    }
}