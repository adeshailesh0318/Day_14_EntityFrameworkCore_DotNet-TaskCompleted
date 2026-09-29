

using Authen.DAL;

public interface IAccountRepositories
{

    bool Register(User user);
    User Login(string email,string password);

}