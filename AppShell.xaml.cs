using Password_Guardian.Views;

namespace Password_Guardian;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(SignUp), typeof(SignUp));
        Routing.RegisterRoute("Login", typeof(Login));
        Routing.RegisterRoute("SignUpSuccess", typeof(SignUpSuccess));
        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("AddNewPassword", typeof(AddNewPassword));
    }

    private async void LogoutBtn_Clicked(object sender, EventArgs e)
    {

        await Shell.Current.GoToAsync("Login");
    }

    private async void DeleteAccount_Clicked(object sender, EventArgs e)
    {
        SecureStorage.Default.RemoveAll();
        await Shell.Current.GoToAsync("SignUp");
    }

    private async void AddNewPasswordBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddNewPassword");
    }
}
