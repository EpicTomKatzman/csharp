﻿using NUnit.Framework;
using RestSharp;
using SdetBootcampDay3.Models;
using System.Net;

namespace SdetBootcampDay3.Exercises
{
    [TestFixture]
    public class Exercises03
    {
        private const string BASE_URL = "http://jsonplaceholder.typicode.com";

        private RestClient client;

        [OneTimeSetUp]
        public void SetupRestSharpClient()
        {
            client = new RestClient(BASE_URL);
        }

        [Test]
        public async Task GetDataForUser1_CheckName_ShouldEqualLeanneGraham()
        {
            /**
             * TODO: Create and execute a new GET request to '/users/1'
             * Deserialize the response body into a new object of type User
             * Verify that the Name property of the user is equal to Leanne Graham
             */
            RestRequest request = new RestRequest("/users/1", Method.Get);

            RestResponse<UserDto> response = await client.ExecuteAsync<UserDto>(request);

            UserDto user = response.Data!;

            Assert.That(response.Data!.Name, Is.EqualTo("Leanne Graham"));


        }

        [Test]
        public async Task PostNewPost_CheckStatusCode_ShouldBeHttpCreated()
        {
            /** 
             * TODO: Create a new Post object with UserId = 1 and a custom Title and Body
             * Create a new POST request to '/posts', add a JSON representation of the
             * Post object and execute the request
             * Verify that the response status code is equal to HttpStatusCode.Created (HTTP 201).
             */
             PostDto post = new PostDto{
             UserId = 1,
             Title = "hey how do you post?",
             Body = "nvm I figured it out."
             };
             RestRequest request = new RestRequest("/posts", Method.Post);
             request.AddJsonBody(post);

             RestResponse response = await client.ExecuteAsync(request);

             Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));





        }
    }
}
