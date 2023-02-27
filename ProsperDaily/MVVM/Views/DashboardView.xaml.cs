using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class DashboardView : ContentPage
{
    DashboardViewModel viewModel = new DashboardViewModel();
	public DashboardView()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    private async void AddTransaction_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new TransactionsView());
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.FillData();   
    }
}