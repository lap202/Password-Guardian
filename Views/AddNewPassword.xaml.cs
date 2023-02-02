using System.Text.Json;
using Password_Guardian.Models;
using CommunityToolkit.Maui.Alerts;

namespace Password_Guardian.Views;

public partial class AddNewPassword : ContentPage
{
    Account account = new Account();
    public AddNewPassword()
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
            await Shell.Current.GoToAsync("SignUp");
        }

        int cardcount = 0;

        if (account._card1Name != null)
        {
            cardcount++;
        }
        if (account._card2Name != null)
        {
            cardcount++;
        }
        if (account._card3Name != null)
        {
            cardcount++;
        }
        if (account._card4Name != null)
        {
            cardcount++;
        }
        if (account._card5Name != null)
        {
            cardcount++;
        }

        if (cardcount == 5)
        {
            NewPasswordForm.IsVisible = false;
            OutOfSpace.IsVisible = true;
        }

    }

    private async void CancelBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("HomePage");
    }

    private async void AddPasswordBtn_Clicked(object sender, EventArgs e)
    {
        string passcardName = txtPassCardName.Text;
        string passcardPassword = txtPassword.Text;
        string passcardUsername = txtPassCardUserName.Text;
        bool isValid = true;

        if (passcardName.Length == 0)
        {
            isValid = false;
            lblErrorSummary.IsVisible = true;
            lblErrorSummary.Text += "* You must enter a name for the card.";
        }

        if (isValid)
        {
            account.createPasscard(passcardName, passcardUsername, passcardPassword);
            account.SaveAccount(account);
            await Shell.Current.GoToAsync("HomePage");

            var toast = Toast.Make("Password created for " + passcardName);
            await toast.Show();
        }
    }
}