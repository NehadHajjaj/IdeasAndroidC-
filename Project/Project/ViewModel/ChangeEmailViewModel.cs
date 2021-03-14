using Project.Helper;
using Project.Model;
using Project.Services;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModel
{
    class ChangeEmailViewModel
    {


		private readonly ApiService _apiService = new ApiService();
		private Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

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
				
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.body, AppResource.ok);

			}
			else if (!EmailRegex.IsMatch(OldEmail))
			{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.emv, AppResource.ok);
			}
			else if (!EmailRegex.IsMatch(NewEmail))
			{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.emv, AppResource.ok);
			}
			else if (ConfirmEmail != NewEmail) {
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.emt, AppResource.ok);
			}
			
			else
			{
				if (Settings.AccessToken == "")
				{
					await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.nonuser, AppResource.ok);
					await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
				}
				else
				{

					var nemail = new NEmail
					{
						OldEmail = OldEmail,
						NewEmail = NewEmail,


					};
					DependencyService.Get<IProgressInterface>().Show();
					var IsChange = await _apiService.ChangeEmailAsync(nemail, Settings.AccessToken);
					DependencyService.Get<IProgressInterface>().Hide();
					if (IsChange)
					{
						Settings.Email = NewEmail;
						await Application.Current.MainPage.Navigation.PushModalAsync(new MainMenu());

					}
					else
					{
						await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.problem, AppResource.ok);
						await Application.Current.MainPage.Navigation.PushModalAsync(new ChangeEmail());
					}
				}
			}
		}
		private async void OpenPage2(string value)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(new ChangeEmail());
		}












	}
}
