using System;
using System.Linq;
using System.Threading.Tasks;
using DataAccess_Layer.Interfaces;
using EfCoreRelationships.DbModel;
using EfCoreRelationships.Model;

namespace BuisnessLogic_Layer;
public class UserService
{
    private readonly IUserRepository userRepository;
    public UserService(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
    }

    public async Task<List<User>> getUsermethod()
    {
        var users = await userRepository.getUser();
        return users;
    }
    public async Task<Boolean> addUser(UserDTO user)
    {
        var userToBeAdded = new User
        {
            Name = user.Name
        };
        var isUserAdded = await userRepository.addUserToDB(userToBeAdded);
        return isUserAdded;
    }
}

