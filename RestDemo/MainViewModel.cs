using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RestDemo
{
    public class MainViewModel
    {
        #region PRIVATE MEMBERS
        private HttpClient client;
        private JsonSerializerOptions serializerOptions;
        private const string baseUrl = "https://63f3d147864fb1d6001e74fa.mockapi.io";
        private List<User> users;
        #endregion

        #region CONSTRUCTORS

        public MainViewModel()
        {
            client = new HttpClient();
            serializerOptions = new JsonSerializerOptions
            {
                WriteIndented = true,
            };
        }

        #endregion

        public ICommand GetAllUserCommand => new Command(async () =>
        {
            var url = $"{baseUrl}/users";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // var content = await response.Content.ReadAsStringAsync();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<List<User>>(responseStream, serializerOptions);
                    users = data;
                }
            }
        });

        public ICommand GetSingleUserCommand => new Command(async () =>
        {
            var url = $"{baseUrl}/users/25";
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // var content = await response.Content.ReadAsStringAsync();
                using (var responseStream = await response.Content.ReadAsStreamAsync())
                {
                    var data = await JsonSerializer.DeserializeAsync<User>(responseStream, serializerOptions);

                }
            }
        });

        public ICommand AddUserCommand => new Command(async () =>
        {
            var url = $"{baseUrl}/users";
            var user = new User
            {
                createdAt = DateTime.Now,
                name = "Hector",
                avatar = "http://fakeimg.pl/350x200?text=MAUI"
            };
            string json = JsonSerializer.Serialize<User>(user, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

        });

        public ICommand UpdateUserCommand => new Command(async () =>
        {
            var user = users.FirstOrDefault(u => u.id == "1");
            var url = $"{baseUrl}/users/1";
            user.name = "John";

            string json = JsonSerializer.Serialize<User>(user, serializerOptions);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content);
        });

        public ICommand DeleteUserCommand => new Command(async () =>
        {
            var url = $"{baseUrl}/users/10";

            var response = await client.DeleteAsync(url);
        });


    }
}
