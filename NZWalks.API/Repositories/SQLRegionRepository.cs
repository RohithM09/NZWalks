using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbContext;
        public SQLRegionRepository(NZWalksDbContext dbContext) 
        { 
            _dbContext = dbContext; 
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _dbContext.Regions.AddAsync(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid Id)
        {
            var region = await _dbContext.Regions.FirstOrDefaultAsync(i=>i.Id== Id);
            if(region==null)
            {
                return null;
            }
            _dbContext.Regions.Remove(region);
            await _dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Regions.FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Region?> UpdateAsync(Guid Id, Region region)
        {
            var fetch = await _dbContext.Regions.FirstOrDefaultAsync(i => i.Id == Id);
            if(fetch==null)
            {
                return null;
            }
            fetch.Code = region.Code;
            fetch.RegionImageUrl = region.RegionImageUrl;
            fetch.Name=region.Name;
            await _dbContext.SaveChangesAsync();
            return fetch;
        }
    }
}
