using Project.Model;
using Project.Services;
using Project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Project.ViewModel
{
	public class AddIdeaViewModel : BaseViewModel
	{
		private readonly ApiService _apiService = new ApiService();

		
		public string Title { get; set; }
		public string Description { get; set; }
		public int IdeaType { get; set; }
		public int IdeaState { get; set; }
		public int ScientificClassification { get; set; }
		public string Des { get; set; }
		public string UserId { get; set; }
		public string UserName { get; set; }

		private Idea _selecteddrop1;
		public Idea SelectedDrop1
		{
			get
			{
				return _selecteddrop1;
			}
			set
			{
				SetValue(ref _selecteddrop1, value);
				//put here your code  
				ScientificClassification = _selecteddrop1.ScientificClassification;
			}
		}
		private Idea _selecteddrop2;
		public Idea SelectedDrop2
		{
			get
			{
				return _selecteddrop2;
			}
			set
			{
				SetValue(ref _selecteddrop2, value);
				//put here your code  
				IdeaType = _selecteddrop2.IdeaType;
			}
		}
		private Idea _selecteddrop3;
		public Idea SelectedDrop3
		{
			get
			{
				return _selecteddrop3;
			}
			set
			{
				SetValue(ref _selecteddrop3, value);
				//put here your code  
				IdeaState = _selecteddrop3.IdeaState;
			}
		}
		public IList<Idea> idealist { get; set; }
		public IList<Idea> idealtype { get; set; }
		public IList<Idea> idealstate { get; set; }
		public string type { get; set; }
		public string state { get; set; }
		public ICommand Submit { get; set; }
		public ICommand Reset { get; set; }
		public AddIdeaViewModel()
		{
			try
			{
				idealist = new ObservableCollection<Idea>();
				idealist.Add(new Idea { ScientificClassification = 1, Des = "Engineering inventions" });
				idealist.Add(new Idea { ScientificClassification = 2, Des = "Technological inventions" });
				idealist.Add(new Idea { ScientificClassification = 3, Des = "Medical inventions" });
				idealist.Add(new Idea { ScientificClassification = 4, Des = "HouseWare inventions" });
				idealist.Add(new Idea { ScientificClassification = 5, Des = "Environmental inventions" });
				idealist.Add(new Idea { ScientificClassification = 6, Des = "Transportation inventions" });
				idealist.Add(new Idea { ScientificClassification = 7, Des = "MachineLearning inventions " });
				idealist.Add(new Idea { ScientificClassification = 8, Des = "InformationSecurity inventions" });

				idealtype = new ObservableCollection<Idea>();
				idealtype.Add(new Idea { IdeaType = 1, type = "inventions" });
				idealtype.Add(new Idea { IdeaType = 2, type = "solve the problem" });
				idealtype.Add(new Idea { IdeaType = 3, type = "creative idea" });

				idealstate = new ObservableCollection<Idea>();
				idealstate.Add(new Idea { IdeaState = 1, state = "complete" });
				idealstate.Add(new Idea { IdeaState = 2, state = "under development" });

				Submit = new Command<string>((arg) => OpenPage(arg));
				Reset = new Command<string>((arg) => OpenPage2(arg));
			}



			catch (Exception) { }

		}


		private async void OpenPage(string value)
		{
			if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(Description) || IdeaType ==0 || IdeaState == 0 || ScientificClassification ==0)
			{
				await App.Current.MainPage.DisplayAlert("Error", "Please Fill the Fields", "Ok");

			}
			else
			{
				var idea = new Idea
				{
					Title = Title,
					Description = Description,
					IdeaType = IdeaType,
					IdeaState = IdeaState,
					ScientificClassification = ScientificClassification,
					
					
				};
				await _apiService.PostIdeaAsync(idea, Settings.AccessToken);
				await Application.Current.MainPage.Navigation.PushModalAsync(new Home());
			}
		}

		private async void OpenPage2(string value)
		{
			await Application.Current.MainPage.Navigation.PushModalAsync(new AddInvetaion());
		}









	}






}








		

	

