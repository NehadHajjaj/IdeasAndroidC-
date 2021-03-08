using System.Windows.Input;

using Xamarin.Forms;

using System.ComponentModel;

using Project.Views;
using Project.Services;
using System.Text.RegularExpressions;
using Project.Helper;

namespace Project.Models
{
    public class RegisterViewModel
    {
        private readonly ApiService _apiService = new ApiService();
        private Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private Regex passwordRegExp = new Regex("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})");

        public string ConfirmPassword { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsStudent { get; set; }
        public bool Student { get; set; }
        public ICommand RegisterCommand { get; set; }
        public RegisterViewModel (){
            RegisterCommand = new Command<string>((arg) => OpenPage(arg));}
        private async void OpenPage(string value)
        {
            if ( string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please Fill the Fields", "Ok");
           
            }
            else if (!passwordRegExp.IsMatch(Password))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Password must contain at least one digit, one uppercase character and one special symbol ", "Ok");
            }
           
            else if (!EmailRegex.IsMatch(Email))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Please Enter a vaild Email ", "Ok");
            }
            else if (Password != ConfirmPassword)
            {
                await App.Current.MainPage.DisplayAlert("Error", "ConfirmPassword doesnt match Password ", "Ok");
            }


            else {
                if (IsStudent) { Student = true; }
                else { Student = false; }
                DependencyService.Get<IProgressInterface>().Show();
                var isRegistered = await _apiService.RegisterUserAsync(Username, Email, Password, ConfirmPassword, Student);


                DependencyService.Get<IProgressInterface>().Hide();
                
               

                if (isRegistered)
                {
                    Settings.Email = Email;
                    Settings.Username = Username;
                    Settings.Password = Password;
                    await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());

                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("sorry! try again this Account is Registerd", "", "Ok");

                    await Application.Current.MainPage.Navigation.PushModalAsync(new SignUp());

                }
            }
        }
               
        }
        }




    //public event PropertyChangedEventHandler PropertyChanged;
    
