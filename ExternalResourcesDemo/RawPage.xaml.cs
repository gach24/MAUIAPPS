using System.Text.Json;

namespace ExternalResourcesDemo;

public partial class RawPage : ContentPage
{
	public RawPage()
	{
		InitializeComponent();
	}
    private async Task LoadMauiAsset()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("data.json");
        using var reader = new StreamReader(stream);

        var contents = reader.ReadToEnd();
        var p = JsonSerializer.Deserialize<Person>(contents);
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadMauiAsset();
    }
}

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}