using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using TheiaBProjectv2.DataModels;

namespace TheiaBProjectv2.HttpRequests
{
    class Request
    {
        string url = "http://ec2-18-218-160-57.us-east-2.compute.amazonaws.com/";

        public async Task<Dictionary<string, dynamic>> login(string email, string password)
        {
            var client = new HttpClient();

            var formcontent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            var request = await client.PostAsync(url + "tb0-1.php", formcontent);

            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);

            return res;
        }

        public async Task<Dictionary<string, dynamic>> signup(string firstname, string lastname, string username, string email, string password, string phoneNumber, string emergencyContact)
        {
            var client = new HttpClient();

            var formcontent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("firstname", firstname),
                new KeyValuePair<string, string>("lastname", lastname),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("phonenumber", phoneNumber),
                new KeyValuePair<string, string>("emergencycontact", emergencyContact),
                new KeyValuePair<string, string>("email", email),
                new KeyValuePair<string, string>("password", password)
            });

            var request = await client.PostAsync(url + "tb0-2.php", formcontent);

            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);

            return res;
        }

        public async Task<Account> GetAccountDetails(string email)
        {
            Account account;

            var client = new HttpClient();

            var formcontent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", email)
            });

            var request = await client.PostAsync(url + "tb1-0.php", formcontent);

            request.EnsureSuccessStatusCode();

            var response = await request.Content.ReadAsStringAsync();
            var res = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(response);

            account = new Account(res["firstname"], res["lastname"], res["email"], res["phonenumber"], res["username"], res["emergencycontact"]);

            return account;
        }

    }
}