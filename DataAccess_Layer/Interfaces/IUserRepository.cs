using System;
using EfCoreRelationships.DbModel;

namespace DataAccess_Layer.Interfaces
{
	public interface IUserRepository
	{
        Task<List<User>> getUser();
        Task<Boolean> addUserToDB(User userToBeAdded);
    }
}

