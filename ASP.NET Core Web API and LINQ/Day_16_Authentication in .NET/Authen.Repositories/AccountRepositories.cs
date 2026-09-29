

using Authen.DAL;
using System.Linq;

public class AccountRepositories : IAccountRepositories
{

    private readonly AuthenDBContext _authenDBContext;

    public AccountRepositories(AuthenDBContext authenDBContext)
    {
        this._authenDBContext = authenDBContext;
    }

    public User Login(string email, string password)
    {
        try
        {
            return _authenDBContext.Users.Include("Role").FirstOrDefault(u => u.Email == email
            && u.Password == password); 
        }
        catch 
        {
            return null;
        }
    }

    public bool Register(User user)
    {
        try
        {
            _authenDBContext.Users.Add(user);
            _authenDBContext.SaveChanges();
            return true;
           
        }
        catch 
        {
            return false;
        }
    }
}