using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories.Abstracts
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
    }
}
