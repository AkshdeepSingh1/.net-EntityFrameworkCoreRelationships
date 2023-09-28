using DataAccess_Layer.Interfaces;
using EfCoreRelationships.Data;
using EfCoreRelationships.DbModel;
using Microsoft.EntityFrameworkCore;

namespace DataAccess_Layer;
public class UserRepository : IUserRepository
{
    private DataContext context;
    public UserRepository(DataContext context)
    {
        this.context = context;
    }
    public async Task<List<User>> getUser()
    {
        var data = await context.Users.ToListAsync();
        var a = 5;
        var b = 10;
        a = a + b;
        var data2 = data.FirstOrDefault()?.Characters;
        return data;
    }
    public async Task<Boolean> addUserToDB(User userToBeAdded)
    {
        try
        { 
        await context.Users.AddAsync(userToBeAdded);
        await context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            return false;
        }
        return true;
    }
}

