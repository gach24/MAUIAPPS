using SQLITEDemo.MVVM.ModelViews;

namespace SQLITEDemo.MVVM.Views;

public partial class MainView : ContentPage
{
	public MainView()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}