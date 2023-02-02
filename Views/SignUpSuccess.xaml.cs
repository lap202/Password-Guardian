namespace Password_Guardian.Views;

public partial class SignUpSuccess : ContentPage
{
    public SignUpSuccess()
    {
        InitializeComponent();
    }

    private async void toLoginBtn_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Login");
    }
}