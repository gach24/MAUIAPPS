using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class TransactionsView : ContentPage
{
    private TransactionViewModel vm = new TransactionViewModel();

    public TransactionsView()
	{
		InitializeComponent();
        BindingContext = vm;

    }

    private async void btnSave_Clicked(object sender, EventArgs e)
    {
        var message = vm.SaveTransaction();
        await DisplayAlert("Info", message, "Ok");
        await Navigation.PopToRootAsync();
    }

    private async void btnCancel_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}