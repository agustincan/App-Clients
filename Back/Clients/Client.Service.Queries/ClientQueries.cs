using Client.Persistence.Database;
using Client.Service.Queries.Dtos;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Client.Service.Queries
{
    public interface IClientQueries
    {
        Task<DataCollection<ClientDto>> GetAllAsync(int page, int take);
        Task<DataCollection<ClientDto>> GetByDescriptionAsync(IEnumerable<int> ids, int page = 1, int take = 20);
        Task<ClientDto> GetByIdAsync(int id);
        Task<DataCollection<ClientDto>> GetByNameAsync(string name, int page = 1, int take = 20);
    }

    public class ClientQueries : IClientQueries
    {
        private readonly AppDbContext context;

        public ClientQueries(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<ClientDto>> GetAllAsync(int page, int take)
        {
            var result = await context.Clients.GetPagedAsync(page, take);
            return result.MapTo<DataCollection<ClientDto>>();
        }
        public async Task<ClientDto> GetByIdAsync(int id)
        {
            var result = await context.Clients.FindAsync(id);
            return result.MapTo<ClientDto>();
        }
        public async Task<DataCollection<ClientDto>> GetByDescriptionAsync(IEnumerable<int> ids, int page = 1, int take = 20)
        {
            var result = await context.Clients.Where(t => ids.Contains(t.Id)).GetPagedAsync(page, take);
            return result.MapTo<DataCollection<ClientDto>>();
        }
        public async Task<DataCollection<ClientDto>> GetByNameAsync(string name, int page = 1, int take = 20)
        {
            var result = await context.Clients.Where(t => t.Names.Contains(name) || t.LastNames.Contains(name)).GetPagedAsync(page, take);
            return result.MapTo<DataCollection<ClientDto>>();
        }
    }
}