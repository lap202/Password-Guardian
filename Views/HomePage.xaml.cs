using Password_Guardian.Models;
using System.Text.Json;
using CommunityToolkit.Maui.Alerts;

namespace Password_Guardian.Views;

public partial class HomePage : ContentPage
{
    Account account;
    public HomePage()
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

        PopulateCards();
    }

    private void PopulateCards()
    {
        int cardcount = 0;

        if (account._card1Name != null)
        {
            cardcount++;
            card1.IsVisible = true;
            lblPasscardName1.Text = account._card1Name;
            txtUsernameBox1.Text = account._card1User;
            txtPasswordBox1.Text = account._card1Pass;
        }
        if (account._card2Name != null)
        {
            cardcount++;
            card2.IsVisible = true;
            lblPasscardName2.Text = account._card2Name;
            txtUsernameBox2.Text = account._card2User;
            txtPasswordBox2.Text = account._card2Pass;
        }
        if (account._card3Name != null)
        {
            cardcount++;
            card3.IsVisible = true;
            lblPasscardName3.Text = account._card3Name;
            txtUsernameBox3.Text = account._card3User;
            txtPasswordBox3.Text = account._card3Pass;
        }
        if (account._card4Name != null)
        {
            cardcount++;
            card4.IsVisible = true;
            lblPasscardName4.Text = account._card4Name;
            txtUsernameBox4.Text = account._card4User;
            txtPasswordBox4.Text = account._card4Pass;
        }
        if (account._card5Name != null)
        {
            cardcount++;
            card5.IsVisible = true;
            lblPasscardName5.Text = account._card5Name;
            txtUsernameBox5.Text = account._card5User;
            txtPasswordBox5.Text = account._card5Pass;
        }
        if (cardcount == 5)
        {
            newPassCard.IsVisible = false;
        }
    }

    private void clipboardToast()
    {
        var toast = Toast.Make("Password has been copied to the clipboard.");
        toast.Show();
    }

    //Copy to Clipboard Buttons
    private async void copyToClipboardBtn_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(txtPasswordBox1.Text);
        clipboardToast();
    }
    private async void copyToClipboardBtn2_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(txtPasswordBox2.Text);
        clipboardToast();
    }
    private async void copyToClipboardBtn3_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(txtPasswordBox3.Text);
        clipboardToast();
    }
    private async void copyToClipboardBtn4_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(txtPasswordBox4.Text);
        clipboardToast();
    }
    private async void copyToClipboardBtn5_Clicked(object sender, EventArgs e)
    {
        await Clipboard.Default.SetTextAsync(txtPasswordBox5.Text);
        clipboardToast();
    }

    //View buttons pressed
    private void viewPasswordBtn_Clicked(object sender, EventArgs e)
    {
        if (txtPasswordBox1.IsPassword)
        {
            txtPasswordBox1.IsPassword = false;
            viewPasswordBtn.Text = "Hide";
        }
        else
        {
            txtPasswordBox1.IsPassword = true;
            viewPasswordBtn.Text = "View";
        }
    }
    private void viewPasswordBtn2_Clicked(object sender, EventArgs e)
    {
        if (txtPasswordBox2.IsPassword)
        {
            txtPasswordBox2.IsPassword = false;
            viewPasswordBtn2.Text = "Hide";
        }
        else
        {
            txtPasswordBox2.IsPassword = true;
            viewPasswordBtn2.Text = "View";
        }
    }
    private void viewPasswordBtn3_Clicked(object sender, EventArgs e)
    {
        if (txtPasswordBox3.IsPassword)
        {
            txtPasswordBox3.IsPassword = false;
            viewPasswordBtn3.Text = "Hide";
        }
        else
        {
            txtPasswordBox3.IsPassword = true;
            viewPasswordBtn3.Text = "View";
        }
    }
    private void viewPasswordBtn4_Clicked(object sender, EventArgs e)
    {
        if (txtPasswordBox4.IsPassword)
        {
            txtPasswordBox4.IsPassword = false;
            viewPasswordBtn4.Text = "Hide";
        }
        else
        {
            txtPasswordBox4.IsPassword = true;
            viewPasswordBtn4.Text = "View";
        }
    }
    private void viewPasswordBtn5_Clicked(object sender, EventArgs e)
    {
        if (txtPasswordBox5.IsPassword)
        {
            txtPasswordBox5.IsPassword = false;
            viewPasswordBtn5.Text = "Hide";
        }
        else
        {
            txtPasswordBox5.IsPassword = true;
            viewPasswordBtn5.Text = "View";
        }
    }

    private async void btnAddNewPassword_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddNewPassword");
    }
    private void ReturnToCard()
    {
        Card1EditButtons.IsVisible = false;
        Card1DefaultBtns.IsVisible = true;
        Card2EditButtons.IsVisible = false;
        Card2DefaultBtns.IsVisible = true;
        Card3EditButtons.IsVisible = false;
        Card3DefaultBtns.IsVisible = true;
        Card4EditButtons.IsVisible = false;
        Card4DefaultBtns.IsVisible = true;
        Card5EditButtons.IsVisible = false;
        Card5DefaultBtns.IsVisible = true;

        txtPasswordBox1.IsEnabled = false;
        txtUsernameBox1.IsEnabled = false;
        txtPasswordBox2.IsEnabled = false;
        txtUsernameBox2.IsEnabled = false;
        txtPasswordBox3.IsEnabled = false;
        txtUsernameBox3.IsEnabled = false;
        txtPasswordBox4.IsEnabled = false;
        txtUsernameBox4.IsEnabled = false;
        txtPasswordBox5.IsEnabled = false;
        txtUsernameBox5.IsEnabled = false;

        txtPasswordBox1.Text = account._card1Pass;
        txtUsernameBox1.Text = account._card1User;
        txtPasswordBox2.Text = account._card2Pass;
        txtUsernameBox2.Text = account._card2User;
        txtPasswordBox3.Text = account._card3Pass;
        txtUsernameBox3.Text = account._card3User;
        txtPasswordBox4.Text = account._card4Pass;
        txtUsernameBox4.Text = account._card4User;
        txtPasswordBox5.Text = account._card5Pass;
        txtUsernameBox5.Text = account._card5User;

        Card1DeleteBtn.IsVisible= false;
        Card2DeleteBtn.IsVisible= false;
        Card3DeleteBtn.IsVisible= false;
        Card4DeleteBtn.IsVisible= false;
        Card5DeleteBtn.IsVisible= false;
    }
    private void CancelEditBtn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
    }

    //Edit button pressed
    private void EditCard1Btn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
        Card1EditButtons.IsVisible = true;
        Card1DefaultBtns.IsVisible = false;
        txtPasswordBox1.IsEnabled = true;
        txtUsernameBox1.IsEnabled = true;
        Card1DeleteBtn.IsVisible = true;
        view2PasswordBtn.Text = viewPasswordBtn.Text;
    }
    private void EditCard2Btn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
        Card2EditButtons.IsVisible = true;
        Card2DefaultBtns.IsVisible = false;
        txtPasswordBox2.IsEnabled = true;
        txtUsernameBox2.IsEnabled = true;
        Card2DeleteBtn.IsVisible = true;
        view2PasswordBtn2.Text = viewPasswordBtn2.Text;
    }
    private void EditCard3Btn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
        Card3EditButtons.IsVisible = true;
        Card3DefaultBtns.IsVisible = false;
        txtPasswordBox3.IsEnabled = true;
        txtUsernameBox3.IsEnabled = true;
        Card3DeleteBtn.IsVisible = true;   
        view2PasswordBtn3.Text= viewPasswordBtn3.Text;
    }
    private void EditCard4Btn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
        Card4EditButtons.IsVisible = true;
        Card4DefaultBtns.IsVisible = false;
        txtPasswordBox4.IsEnabled = true;
        txtUsernameBox4.IsEnabled = true;
        Card4DeleteBtn.IsVisible = true;
        view2PasswordBtn4.Text= viewPasswordBtn4.Text;
    }
    private void EditCard5Btn_Clicked(object sender, EventArgs e)
    {
        ReturnToCard();
        Card5EditButtons.IsVisible = true;
        Card5DefaultBtns.IsVisible = false;
        txtPasswordBox5.IsEnabled = true;
        txtUsernameBox5.IsEnabled = true;
        Card5DeleteBtn.IsVisible = true;
        view2PasswordBtn5.Text = viewPasswordBtn5.Text;

    }

    //Edit Card Save
    private void Card1SaveEditBtn_Clicked(object sender, EventArgs e)
    {
        account._card1User = txtUsernameBox1.Text;
        account._card1Pass = txtPasswordBox1.Text;
        account.SaveAccount(account);
        ReturnToCard();
    }
    private void Card2SaveEditBtn_Clicked(object sender, EventArgs e)
    {
        account._card2User = txtUsernameBox2.Text;
        account._card2Pass = txtPasswordBox2.Text;
        account.SaveAccount(account);
        ReturnToCard();
    }
    private void Card3SaveEditBtn_Clicked(object sender, EventArgs e)
    {
        account._card3User = txtUsernameBox3.Text;
        account._card3Pass = txtPasswordBox3.Text;
        account.SaveAccount(account);
        ReturnToCard();
    }
    private void Card4SaveEditBtn_Clicked(object sender, EventArgs e)
    {
        account._card4User = txtUsernameBox4.Text;
        account._card4Pass = txtPasswordBox4.Text;
        account.SaveAccount(account);
        ReturnToCard();
    }
    private void Card5SaveEditBtn_Clicked(object sender, EventArgs e)
    {
        account._card5User = txtUsernameBox5.Text;
        account._card5Pass = txtPasswordBox5.Text;
        account.SaveAccount(account);
        ReturnToCard();
    }

    //Delete buttons
    private async void Card1DeleteBtn_Clicked(object sender, EventArgs e)
    {
        account._card1User = null;
        account._card1Pass = null;
        account._card1Name = null;
        account.SaveAccount(account);
        await Shell.Current.GoToAsync("HomePage");
    }
    private async void Card2DeleteBtn_Clicked(object sender, EventArgs e)
    {
        account._card2User = null;
        account._card2Pass = null;
        account._card2Name = null;
        account.SaveAccount(account);
        await Shell.Current.GoToAsync("HomePage");
    }
    private async void Card3DeleteBtn_Clicked(object sender, EventArgs e)
    {
        account._card3User = null;
        account._card3Pass = null;
        account._card3Name = null;
        account.SaveAccount(account);
        await Shell.Current.GoToAsync("HomePage");
    }
    private async void Card4DeleteBtn_Clicked(object sender, EventArgs e)
    {
        account._card4User = null;
        account._card4Pass = null;
        account._card4Name = null;
        account.SaveAccount(account);
        await Shell.Current.GoToAsync("HomePage");
    }
    private async void Card5DeleteBtn_Clicked(object sender, EventArgs e)
    {
        account._card5User = null;
        account._card5Pass = null;
        account._card5Name = null;
        account.SaveAccount(account);
        await Shell.Current.GoToAsync("HomePage");
    }
}