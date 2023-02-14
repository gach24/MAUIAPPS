using MauiVerter.MVVM.ViewModels;

namespace MauiVerter.MVVM.Views;

public partial class MenuView : ContentPage
{
	public MenuView()
	{
		InitializeComponent();
		BindingContext = new MenuViewModel();
	}

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		var element = sender as Grid;
		var option = ((Label)element.Children.LastOrDefault()).Text;
		var converterPage = new ConverterPage()
		{
			BindingContext = new ConverterViewModel(option)
		};
		Navigation.PushAsync(converterPage);
    }
}