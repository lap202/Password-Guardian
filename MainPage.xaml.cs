namespace Password_Guardian;

public partial class MainPage : ContentPage
{
	int count = 0;

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

