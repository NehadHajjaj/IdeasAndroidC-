using Project.Model;
using Project.Services;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModel
{
    class ChangeEmailViewModel
    {


		//private readonly ApiService _apiService = new ApiService();


		public string OldEmail { get; set; }
		public string NewEmail { get; set; }
		public string ConfirmEmail { get; set; }
		public ICommand Save { get; set; }
		public ICommand Reset { get; set; }
		public ChangeEmailViewModel()
		{

			Save = new Command<string>((arg) => OpenPage(arg));
			Reset = new Command<string>((arg) => OpenPage2(arg));







		}


		private async void OpenPage(string value)
		{

			if (string.IsNullOrWhiteSpace(NewEmail) || string.IsNullOrWhiteSpace(OldEmail) || string.IsNullOrWhiteSpace(ConfirmEmail) )
			{
				await App.Current.MainPage.DisplayAlert("Error", "Please Fill the Fields", "Ok");

			}
			else if (ConfirmEmail != NewEmail) {
				await App.Current.MainPage.DisplayAlert("Error", "NewEmail and Confirm doesnt match", "Ok");
			}
			else
			{

				var nemail = new NEmail
				{
					OldEmail = OldEmail,
					NewEmail = NewEmail,
					

				};
				Settings.Email = NewEmail;
				//await _apiService.ChangeEmailAsync(nemail, Settings.AccessToken);
				await Application.Current.MainPage.Navigation.PushModalAsync(new Home());
			}
		}
		private async void OpenPage2(string value)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(new ChangeEmail());
		}












	}
}
