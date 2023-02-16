using CollectionViewDemo.MVVM.ViewModels;

namespace CollectionViewDemo.MVVM.Views;

public partial class LayoutView : ContentPage
{
	public LayoutView()
	{
		InitializeComponent();
		BindingContext = new DataViewModel();
	}

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		var element = e.CurrentSelection;
    }
}