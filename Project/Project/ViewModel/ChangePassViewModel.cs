using Project.Model;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModel
{
	class ChangePassViewModel
	{
		//private readonly ApiService _apiService = new ApiService();
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
			await App.Current.MainPage.DisplayAlert("Error", "Please Fill the Fields", "Ok");

		}
		else if (NewPass != ConfirmPass)
		{
			await App.Current.MainPage.DisplayAlert("Error", "NewPass and Confirm doesnt match", "Ok");
		}
		else
		{

			var npass = new NPass
			{
				OldPass = OldPass,
				NewPass = NewPass,
				ConfirmPass= ConfirmPass

			};
			Settings.Password = NewPass;
			//await _apiService.ChangePassAsync(npass, Settings.AccessToken);
			await Application.Current.MainPage.Navigation.PushModalAsync(new Home());
		}
	}
	private async void OpenPage2(string value)
	{
		await Application.Current.MainPage.Navigation.PushModalAsync(new ChangePassword());
	}

}
}
