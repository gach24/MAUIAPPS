using CollectionViewDemo.MVVM.ViewModels;
using System.Diagnostics;

namespace CollectionViewDemo.MVVM.Views;

public partial class ProductsView : ContentPage
{
	public ProductsView()
	{
		InitializeComponent();
		BindingContext = new ProductsViewModel();
	}

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
		Debug.WriteLine("-------------------------------------------");
		Debug.WriteLine("HorizontalDelta:" + e.HorizontalDelta);
		Debug.WriteLine("VerticalDelta: " + e.VerticalDelta);
		Debug.WriteLine("HorizontalOffset: " + e.HorizontalOffset);
		Debug.WriteLine("VerticalOffset: " + e.VerticalOffset);
		Debug.WriteLine("FirstVisibleItemIndex: " + e.FirstVisibleItemIndex);
		Debug.WriteLine("CenterItemIndex: " + e.CenterItemIndex);
		Debug.WriteLine("LastVisibleItemIndex: " + e.LastVisibleItemIndex);
		Debug.WriteLine("-------------------------------------------");
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
		// collectionView.ScrollTo(10);
		var viewModel = BindingContext as ProductsViewModel;

		// var product = viewModel.Products.SelectMany(p => p).FirstOrDefault(p => p.Id == 10);
		// collectionView.ScrollTo(product, animate: false, position: ScrollToPosition.Center);
		viewModel.Products.Add(new Models.ProductsGroup("New Group",
			new List<Models.Product>
			{
				new Models.Product
				{
					Id = 100,
					Name = "Bitcoint",
					Price = 9999
				}
			}));

    }
}