using ProsperDaily.MVVM.ViewModels;

namespace ProsperDaily.MVVM.Views;

public partial class StatisticView : ContentPage
{
	private StatisticsViewModel viewModel = new StatisticsViewModel();
	public StatisticView()
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		viewModel.GetTransactionsSummary();

    }
}