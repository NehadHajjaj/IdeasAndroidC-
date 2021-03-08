using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Project.Model;
using Project.Models;


namespace Project.Services
{
	public class ApiService
	{
		public async Task<bool> RegisterUserAsync(String username, String email, String password, String confirmpassword, bool isstudent)
		{

			//var client = new HttpClient();
			var client = new HttpClient(new System.Net.Http.HttpClientHandler());

			var model = new RegisterBindingModel
			{
				Email = email,
				Username = username,
				Password = password,
				ConfirmPassword = confirmpassword,
				IsStudent = isstudent

			};

			var json = JsonConvert.SerializeObject(model);

			HttpContent httpContent = new StringContent(json);

			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/Register", httpContent);

			Debug.WriteLine(response.IsSuccessStatusCode);

			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task <bool> PostIdeaAsync(Idea idea, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(idea);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Ideas", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task <bool> PostUserAsync(UserInfo userinfo, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(userinfo);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/PostInfo", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task<bool> ChangeEmailAsync(NEmail nemail, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(nemail);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/ChangeEmail", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;

		}
		public async Task<bool> ChangePassAsync(NPass npass, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(npass);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/ChangePassword", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task <bool>PostConsDissAsync(Diss diss, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(diss);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Discussion", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task <bool> PostGDissAsync(Diss diss, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(diss);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Discussion", content);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task  <bool> Logout(string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/Logout", null);
			if (response.IsSuccessStatusCode)
			{
				return true;

			}

			return false;
		}
		public async Task<List<Idea>> GetIdeasAsync(string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				"Bearer", accessToken);

			var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Ideas/ForCurrentUser");

			var ideas = JsonConvert.DeserializeObject<List<Idea>>(json);

			return ideas;
		}
		public async Task<List<Diss>> GetdissAsync(string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
				"Bearer", accessToken);

			var json = await client.GetStringAsync(Constants.BaseApiAddress + "api/Discussions/ForCurrentUser");
			var diss = JsonConvert.DeserializeObject<List<Diss>>(json);
			return diss;
			

		}
		public async Task<List<News>> GetNews()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
		   "Bearer", Settings.AccessToken);
			var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/News");


			List<News> news = JsonConvert.DeserializeObject<List<News>>(response);

			return news;


		}
		
		public async Task<List<Event>> GetEvent()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
			   "Bearer", Settings.AccessToken);
			var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/Event");

			List<Event> myData = JsonConvert.DeserializeObject<List<Event>>(response);

			return myData;

		
           
		}

	
		
			
			
			

			
		
		public async Task<List<Course>> GetCourse()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
			   "Bearer", Settings.AccessToken);
			var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/Course");

			List<Course> courses = JsonConvert.DeserializeObject<List<Course>>(response);

			return courses;
		}

		public async Task<List<WorkShop>> GetWorkShop()
		{
			var httpClient = new HttpClient();
			httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
			   "Bearer", Settings.AccessToken);
			var response = await httpClient.GetStringAsync(Constants.BaseApiAddress + "api/Workshop");

			List<WorkShop> workshop = JsonConvert.DeserializeObject<List<WorkShop>>(response);

			return workshop;
		}









		public async Task<string> LoginAsync(string userName, string password)
		{
			var keyValues = new List<KeyValuePair<string, string>>
			{
				new KeyValuePair<string, string>("username", userName),
				new KeyValuePair<string, string>("password", password),
				new KeyValuePair<string, string>("grant_type", "password")
			};

			var request = new HttpRequestMessage(
				HttpMethod.Post, Constants.BaseApiAddress + "Token");

			request.Content = new FormUrlEncodedContent(keyValues);

			//var client = new HttpClient();
			var client = new HttpClient(new System.Net.Http.HttpClientHandler());
			var response = await client.SendAsync(request);

			var content = await response.Content.ReadAsStringAsync();
			//var chRequest = JsonConvert.DeserializeObject(content);
			dynamic jwtDynamic = JObject.Parse(content);
			var accessTokenExpiration = jwtDynamic.Value<DateTime>(".expires");
			var accessToken = jwtDynamic.Value<string>("access_token");

			Settings.AccessTokenExpirationDate = accessTokenExpiration;

			//Debug.WriteLine(accessTokenExpiration);

			//Debug.WriteLine(content);

			return accessToken;
		}

       
    
	
}
}