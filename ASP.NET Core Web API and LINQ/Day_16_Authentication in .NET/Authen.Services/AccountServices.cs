
using Authen.DAL;
using System;

public class AccountServices : IAccountServices
{

    private readonly IAccountRepositories _repository;

    public AccountServices(IAccountRepositories repository)
    {
        _repository = repository;
    }

    public UserModel Login(string email, string password)
    {
       User dbUser =
            _repository.Login(email, password);


        if (dbUser != null) 
        {
        
            UserModel userModel = new UserModel() 
            {
                UserId = dbUser.Id,
                UserName = dbUser.Name,
                Email = dbUser.Email,
                RoleId = dbUser.Id,
                RoleName = dbUser.Role.Name,
            };

            return userModel;
            
        }
        return null;
    }

    public bool Register(UserModel user)
    {
        try
        {
            User dbUser = new User()
            {
                Id = user.UserId,
                Name = user.UserName,
                Email = user.Email,
                Password = user.Password,
                RoleId = 2,
            };
            return _repository.Register(dbUser);
        }
        catch 
        {

            return false;
        }
    }
}
