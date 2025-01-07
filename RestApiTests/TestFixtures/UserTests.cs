using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestApiTests.Models.Users;
using FluentAssertions;

namespace RestApiTests.TestFixtures
{
   
    internal class UserTests
    {
        [Test]
        public void GetUsers()
        {

            var endPoint = "https://reqres.in/api/users";

            var client = new RestClient(endPoint);
            var  request = new RestRequest();
            request.Method = Method.Get;

            var response = client.Execute(request);

            var responseBody = 
                JsonConvert.DeserializeObject<UserResponse>(response.Content);

            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            responseBody.page.Should().Be(1);
            
        }
    }

}
