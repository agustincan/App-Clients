using AutoMapper;
using Client.Domain;
using Client.Persistence.Database;
using Client.Service.EventHandler.Command;
using Common.Utils;
using MediatR;
using System.Globalization;

namespace Client.Service.EventHandler
{
    internal class ClientCreateHandler : IRequestHandler<ClientCreateCommand, ClientTbl>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ClientCreateHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<ClientTbl> Handle(ClientCreateCommand request, CancellationToken cancellationToken)
        {
            
            var aObject = new ClientTbl()
            {
                Names = request.Names,
                LastNames = request.LastNames,
                Address = request.Address,
                BirthDate = request.BirthDate.StringToDateTime(),
                Cuit = request.Cuit,
                CelularPhone = request.CelularPhone,
                Email = request.Email
            };

            await context.Clients.AddAsync(aObject);
            await context.SaveChangesAsync();
            return aObject;

        }
    }
}