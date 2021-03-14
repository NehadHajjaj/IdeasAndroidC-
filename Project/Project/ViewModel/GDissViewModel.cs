
using Project.Helper;
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
	class GDissViewModel
	{
		private readonly ApiService _apiService = new ApiService();



		public string DiscussionText { get; set; }
		public int Type { get; set; }

		public ICommand Send { get; set; }

		public GDissViewModel()
		{
			try
			{

				Send = new Command<string>((arg) => OpenPage(arg));

			}



			catch (Exception) { }

		}


		private async void OpenPage(string value)
		{
			if (string.IsNullOrWhiteSpace(DiscussionText))
			{
				await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.dissw, AppResource.ok);

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
					var gdiss = new Diss
					{
						DiscussionText = DiscussionText,
						Type = 1,
					};
					DependencyService.Get<IProgressInterface>().Show();


					var isAutho = await _apiService.PostGDissAsync(gdiss, Settings.AccessToken);
					DependencyService.Get<IProgressInterface>().Hide();
					if (isAutho)
					{
						await Application.Current.MainPage.Navigation.PushModalAsync(new Consulting());
					}
					else
					{
						await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.nonuser, AppResource.ok);
						await Application.Current.MainPage.Navigation.PushModalAsync(new LoginPage());

					}

				}
			}
		}










	}






}