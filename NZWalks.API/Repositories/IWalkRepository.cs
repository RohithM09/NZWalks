using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();

        Task<Walk?> GetWalkAsync(Guid Id);

        Task<Walk?> UpdateAsync(Guid Id,Walk walk);
        Task<Walk?> DeleteAsync(Guid Id);
    }
}
