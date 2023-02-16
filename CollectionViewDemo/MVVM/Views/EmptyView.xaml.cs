namespace CollectionViewDemo.MVVM.Views;

public partial class EmptyView : ContentPage
{
	public EmptyView()
	{
		InitializeComponent();
	}

    private void Switch_Toggled(object sender, ToggledEventArgs e)
    {
		var isToogled = e.Value;
		collectionView.EmptyView = isToogled ?
			Resources["NoResultsView"] :
			Resources["ConnectivityIssue"];

    }
}