using System;
using DependencyInjectionExamples.Interfaces;

namespace DependencyInjectionExamples.Repositories
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
        }

        public string GetEmail()
        {
            return "brent@snapspot.io";
        }

        public string GetUserName()
        {
            return "hump_truck";
        }
    }
}
