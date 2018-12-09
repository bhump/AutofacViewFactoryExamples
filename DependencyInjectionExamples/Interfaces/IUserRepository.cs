using System;
namespace DependencyInjectionExamples.Interfaces
{
    public interface IUserRepository
    {
        string GetUserName();

        string GetEmail();
    }
}
