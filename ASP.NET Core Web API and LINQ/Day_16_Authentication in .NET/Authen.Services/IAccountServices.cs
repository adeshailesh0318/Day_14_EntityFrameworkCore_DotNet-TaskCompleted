
using Authen.DAL;

public interface IAccountServices
{
    bool Register(UserModel user);
    UserModel Login(string email, string password);


}