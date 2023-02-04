namespace Password_Guardian;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		LoadApplication();
	}

	private async void LoadApplication()
	{
		await Shell.Current.GoToAsync("SignUp");
    }
}

