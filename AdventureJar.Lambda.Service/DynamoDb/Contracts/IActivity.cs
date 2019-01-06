using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureJar.Lambda.Contracts.Models;

namespace AdventureJar.Lambda.Service.DynamoDb.Contracts
{
    public interface IActivity
    {
        Task<List<ActivityModel>> FindAll();

        Task<ActivityModel> AddActivity(ActivityModel model);

        Task<ActivityModel> UpdateActivity(ActivityModel model);

        Task<ActivityModel> SelectRandom();
    }
}
