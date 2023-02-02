using Password_Guardian.Models;
using System.Text.Json;

namespace Password_Guardian.Views;

public partial class SignUp : ContentPage
{
    public SignUp()
    {
        InitializeComponent();
        checkAccount();
    }

    private async void checkAccount()
    {
        if (await SecureStorage.Default.GetAsync("Account") != null)
        {
            Account account = JsonSerializer.Deserialize<Account>(await SecureStorage.Default.GetAsync("Account"));
            await Shell.Current.GoToAsync("Login");
        }
    }

    private async void SignUpBtn_Clicked(object sender, EventArgs e)
    {
        bool IsValid = true;
        lblErrorSummary.Text = "";
        string username = txtUserName.Text;
        string password1 = txtPassword.Text;
        string password2 = txtConfirmPassword.Text;
        string name = txtName.Text;

        //Verify Name
        if (name.Length == 0)
        {
            IsValid = false;
            lblErrorSummary.Text += "* A name must be entered\n";
        }
        if (name.Length > 12)
        {
            IsValid = false;
            lblErrorSummary.Text += "* The name must be shorter than 12 characters\n";
        }

        //Verify Username
        if (username.Length == 0)
        {
            IsValid = false;
            lblErrorSummary.Text += "* A username must be entered\n";
        }

        //Verify Password
        if (password1.Length == 0)
        {
            IsValid = false;
            lblErrorSummary.Text += "* A password must be entered\n";
        }
        if (password1.Length < 8)
        {
            IsValid = false;
            lblErrorSummary.Text += "* Password must be atleast 8 Characters Long\n";
        }

        //Check for a capital letter
        int uppers = 0;
        foreach (char c in password1)
        {
            if (Char.IsUpper(c))
            {
                uppers += 1;
            }
        }
        if (uppers == 0)
        {
            IsValid = false;
            lblErrorSummary.Text += "* Password must contain a capital letter\n";
        }

        if (password1 != password2)
        {
            IsValid = false;
            lblErrorSummary.Text += "* Your passwords do not match\n";
        }

        if (IsValid)
        {
            Account account = new Account(name, username, password1);
            account.SaveAccount(account);
            await Shell.Current.GoToAsync("SignUpSuccess");
        }
        else
        {
            lblErrorSummary.IsVisible = true;
        }
    }
}