using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository:IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public SQLWalkRepository(NZWalksDbContext dbContext) {
        _dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<Walk?> DeleteAsync(Guid Id)
        {
            var result = await _dbContext.Walks.FirstOrDefaultAsync(i=>i.Id == Id);
            if(result == null)
            {
                return null;
            }
            _dbContext.Walks.Remove(result);
            await _dbContext.SaveChangesAsync();
            return result;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            var res = await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            return res;
        }

        public async Task<Walk?> GetWalkAsync(Guid Id)
        {
           var output = await _dbContext.Walks.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.Id == Id);
           return output;
        }

        public async Task<Walk?> UpdateAsync(Guid Id, Walk walk)
        {
           var result = await _dbContext.Walks.FirstOrDefaultAsync(i=>i.Id== Id);

            if(result==null)
            {
                return null;
            }
            result.Name=walk.Name;
            result.Description=walk.Description;
            result.LengthInKm=walk.LengthInKm;
            result.WalkImageUrl=walk.WalkImageUrl;
            result.DifficultyId=walk.DifficultyId;
            result.RegionId=walk.RegionId;

            await _dbContext.SaveChangesAsync();
            return result;

        }
    }
}
