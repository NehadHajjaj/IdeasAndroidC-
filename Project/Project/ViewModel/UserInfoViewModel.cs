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
	class UserInfoViewModel
	{



		private readonly ApiService _apiService = new ApiService();


		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string Nationality { get; set; }
		public string BirthCountry { get; set; }
		public string Mobile { get; set; }
		public string AcademicQualification { get; set; }
		public ICommand Submit { get; set; }
		public ICommand RadioButton1Command { get; }
		public bool female { get; set; }
		public bool male { get; set; }
		public bool term { get; set; }
		

		public UserInfoViewModel()
			{
				
					Submit = new Command<string>((arg) => OpenPage(arg));
					
			



				

			}


			private async void OpenPage(string value)
			{

				if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName)  || string.IsNullOrWhiteSpace(Nationality) || string.IsNullOrWhiteSpace(BirthCountry) || string.IsNullOrWhiteSpace(Mobile) || string.IsNullOrWhiteSpace(AcademicQualification) || !term)
			{
					await App.Current.MainPage.DisplayAlert(AppResource.er, AppResource.body, AppResource.ok);

				}
				else
				{
				
				if (female) {
					Gender = 1; } else
				{
					Gender = 2;
				}




				var userinfo = new UserInfo
					{
						FirstName = FirstName,
						LastName = LastName,
						Gender = Gender,
						Nationality = Nationality,
						BirthCountry = BirthCountry,
						Mobile= Mobile,
						AcademicQualification= AcademicQualification

					};
				Settings.Mobile = Mobile; 
				DependencyService.Get<IProgressInterface>().Show();
				var isAutho = await _apiService.PostUserAsync(userinfo, Settings.AccessToken);

				DependencyService.Get<IProgressInterface>().Hide();
				
				if (isAutho)
				{
					await Application.Current.MainPage.Navigation.PushModalAsync(new MainMenu());
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













