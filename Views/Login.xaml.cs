using Password_Guardian.Models;
using Microsoft.Maui.Storage;
using System.Text.Json;

namespace Password_Guardian.Views;

public partial class Login : ContentPage
{
    Account account;

    public Login()
    {
        InitializeComponent();
        checkAccount();
    }

    private async void checkAccount()
    {
        if (await SecureStorage.Default.GetAsync("Account") != null)
        {
            account = JsonSerializer.Deserialize<Account>(await SecureStorage.Default.GetAsync("Account"));
        }
        else
        {
            await Shell.Current.GoToAsync(nameof(SignUp));
        }
    }


    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        string username = txtUserName.Text;
        string password = txtPassword.Text;

        if (account.Login(username, password))
        {
            await Shell.Current.GoToAsync("HomePage");
        }
        else
        {
            lblLoginError.IsVisible = true;
        }
    }
}