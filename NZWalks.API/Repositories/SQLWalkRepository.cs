using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Migrations;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
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

        public async Task<List<Walk>> GetAllAsync(string? filterOn=null, string? filterQuery=null,string? sortBy=null,bool isAscending=true,int pageNumber=1,int pageSize=1000)
        {
            var walks = _dbContext.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                }
            }
            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }
            //pagination
            var skipResults = (pageNumber - 1) * pageSize;


            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            //var res = await _dbContext.Walks.Include("Difficulty").Include("Region").ToListAsync();
            //return res;
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
