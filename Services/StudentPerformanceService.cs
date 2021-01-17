/*
Peter Clayton, 12-04-2020
COURSE: CS652-Hadoop/NoSQL
University of Bridgeport
Master's Candidate May 2021
Department of Engineering

StudentPerformanceService:
Purpose: Translates UI and Page functions into api requests while providing loose coupling for Dependency Injection
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using StudentPerformanceAPI.Models;
using StudentPerformanceApp.Pages.FormModels;

namespace StudentPerformanceApp.Data
{
    public class StudentPerformanceService : IStudentPerformanceService
    {
        private readonly HttpClient httpClient;

        // provide live and development api base url
        private string serviceUrl = "https://studentperformanceapideploy.azurewebsites.net/";
        // development: private string serviceUrl = "https://localhost:44303/";


        public StudentPerformanceService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        // Creates a user
        public async Task<User> CreateUserAsync(string collection, UserFormModel userModel)
        {
            // Creates a User object based on supplied values
            User convertedUserModel = new User {
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                UserId = userModel.UserId,
                Designation = userModel.Designation
            };

            string searchQuery = serviceUrl + "createuser/" + collection;

            // External API Call
            var result = await httpClient.PostAsJsonAsync<User>(searchQuery, convertedUserModel);
            try
            {
                result.EnsureSuccessStatusCode();
                return convertedUserModel; // return to display information on successful create
            }
            catch
            {
                return null;
            }
        }

        // Delete a user
        public async Task<string> DeleteUsersAsync(string collection, string filter)
        {
            string searchQuery = serviceUrl + "deleteuser/" + collection + "/" + filter;
            try
            {
                User testUser = new User();
                string res = "";
                // External API Call
                var result = (await httpClient.PostAsJsonAsync<string>(searchQuery, res));
                res = result.Content.ReadAsStringAsync().Result;

                return res;
            }
            catch
            {
                return "Error Occurred";
            }
        }

        // Read list of users from the database
        public async Task<IEnumerable<User>> GetUsersAsync(string collection, string filter)
        {
            string searchQuery = serviceUrl + "getusers/" + collection + "/" + filter;
            // External API Call
            return await httpClient.GetFromJsonAsync<IEnumerable<User>>(searchQuery);
        }

        // Read the full list of users from the database
        public async Task<IEnumerable<User>> ListAllUsersAsync()
        {
            // External API Call
            return await httpClient.GetFromJsonAsync<IEnumerable<User>>(serviceUrl);
        }

        // Update the relevant record in the database
        public async Task<bool> UpdateCollectionAsync(string container, string filterKey, string filterValue, string updateKey, string updateValue)
        {
            string searchQuery = serviceUrl + "update/" + container + "/"+ filterKey+"/"+filterValue + "/" +updateKey + "/" +updateValue;

            // External API Call
            var result = await httpClient.PostAsJsonAsync<string>(searchQuery,searchQuery);

            try
            {
                result.EnsureSuccessStatusCode();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
