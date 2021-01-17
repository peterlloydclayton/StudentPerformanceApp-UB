/*
Peter Clayton, 12-04-2020
COURSE: CS652-Hadoop/NoSQL
University of Bridgeport
Master's Candidate May 2021
Department of Engineering

IStudentPerformanceService:
Purpose: Interface for translating UI and Page functions into api requests while providing loose coupling for Dependency Injection
*/

using StudentPerformanceAPI.Models;
using StudentPerformanceApp.Pages.FormModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudentPerformanceApp.Data
{
    public interface IStudentPerformanceService
    {
        public Task<IEnumerable<User>> ListAllUsersAsync();
        public Task<User> CreateUserAsync(string collection, UserFormModel userModel);
        public Task<IEnumerable<User>> GetUsersAsync(string container, string filter);
        public Task<bool> UpdateCollectionAsync(string container, string filterKey, string filterValue, string updateKey, string updateValue);
        public Task<string> DeleteUsersAsync(string collection, string filter);

    }
}