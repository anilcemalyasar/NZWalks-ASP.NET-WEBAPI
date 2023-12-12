using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;
using NZWalksAPI.Repositories.Abstracts;

namespace NZWalksAPI.Repositories.Concretes
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext _dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext) { 
            _dbContext  = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _dbContext.Walks.AddAsync(walk);
            await _dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await _dbContext.Walks
                .Include("Region")
                .Include("Difficulty")
                .FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk is null)
            {
                return null;
            }

            _dbContext.Walks.Remove(existingWalk);
            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _dbContext.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Walks
                .Include("Region")
                .Include("Difficulty")
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await _dbContext.Walks
                .Include("Region")
                .Include("Difficulty")
                .FirstOrDefaultAsync(w => w.Id == id);

            if (existingWalk is null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
