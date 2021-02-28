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
		public async Task<bool> RegisterUserAsync(String username, String email, String password, String confirmpassword , bool isstudent)
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
		public async Task PostIdeaAsync(Idea idea, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(idea);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Ideas", content);
		}
		public async Task PostUserAsync(UserInfo userinfo, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(userinfo);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/PostInfo", content);
		}
		public async Task ChangeEmailAsync(NEmail nemail, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(nemail);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/ChangeEmail", content);
		}
		public async Task ChangePassAsync(NPass npass, string accessToken)
		{
			var client = new HttpClient();
			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

			var json = JsonConvert.SerializeObject(npass);
			HttpContent content = new StringContent(json);
			content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

			var response = await client.PostAsync(Constants.BaseApiAddress + "api/Account/ChangePassword", content);
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