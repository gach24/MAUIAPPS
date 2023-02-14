using MauiVerter.MVVM.ViewModels;

namespace MauiVerter.MVVM.Views;

public partial class ConverterPage : ContentPage
{
	public ConverterPage()
	{
		InitializeComponent();
	}

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		var viewModel = (ConverterViewModel)BindingContext;
		viewModel.Convert();
    }
}