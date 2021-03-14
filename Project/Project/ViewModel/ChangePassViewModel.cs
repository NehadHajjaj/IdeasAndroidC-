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
	class ChangePassViewModel
	{
		private readonly ApiService _apiService = new ApiService();
		private Regex passwordRegExp = new Regex("((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})");
		public string OldPass { get; set; }
		public string NewPass { get; set; }
		public string ConfirmPass { get; set; }
		public ICommand Save { get; set; }
		public ICommand Reset { get; set; }
	

	public ChangePassViewModel()
	{

		Save = new Command<string>((arg) => OpenPage(arg));
		Reset = new Command<string>((arg) => OpenPage2(arg));

	}


	private async void OpenPage(string value)
	{

		if (string.IsNullOrWhiteSpace(OldPass) || string.IsNullOrWhiteSpace(NewPass) || string.IsNullOrWhiteSpace(ConfirmPass))
		{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.body, AppResource.ok);

			}
			else if (!passwordRegExp.IsMatch(OldPass))
			{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.passv, AppResource.ok);
			}
			else if (!passwordRegExp.IsMatch(NewPass))
			{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.passv, AppResource.ok);
			}
			else if (NewPass != ConfirmPass)
		{
			await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.passt, AppResource.ok);
		}
		else
		{

				if (Settings.AccessToken == "")
				{
					await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.nonuser, AppResource.ok);
					await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());
				}
				else { 
				var npass = new NPass
			{
				OldPass = OldPass,
				NewPass = NewPass,
				ConfirmPass= ConfirmPass

			};
				DependencyService.Get<IProgressInterface>().Show();
				var IsChange = await _apiService.ChangePassAsync(npass, Settings.AccessToken);
				DependencyService.Get<IProgressInterface>().Hide();
				
				if (IsChange)
				{
					Settings.Password = NewPass;
					await Application.Current.MainPage.Navigation.PushModalAsync(new MainMenu());

				}
				else
				{
						await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.problem, AppResource.ok);
						await Application.Current.MainPage.Navigation.PushModalAsync(new ChangePassword());
				}
				}
			}
	}
	private async void OpenPage2(string value)
	{
		await Application.Current.MainPage.Navigation.PushModalAsync(new ChangePassword());
	}

}
}
