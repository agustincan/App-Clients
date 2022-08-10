using AutoMapper;
using Client.Domain;
using Client.Persistence.Database;
using Client.Service.EventHandler.Command;
using MediatR;
using Service.Common.Exceptions;

namespace Client.Service.EventHandler
{
    internal class ClientUpdateHandler : IRequestHandler<ClientUpdateCommand, int>
    {
        private readonly AppDbContext context;
        private readonly IMapper mapper;

        public ClientUpdateHandler(AppDbContext context, IMapper mapper)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context)); ;
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper)); ;
        }
        public async Task<int> Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        {
            var clientToUpdate = await context.Clients.FindAsync(request.Id);

            if (clientToUpdate == null)
            {
                throw new NotFoundException(nameof(ClientTbl), request.Id);
            }
            mapper.Map(request, clientToUpdate, typeof(ClientUpdateCommand), typeof(ClientTbl));
            return await context.SaveChangesAsync();

        }
        //public async Task Handle(ClientUpdateCommand request, CancellationToken cancellationToken)
        //{
        //    var clientToUpdate = await context.Clients.FindAsync(request.Id);

        //    if (clientToUpdate == null)
        //    {
        //        throw new NotFoundException(nameof(ClientTbl), request.Id);
        //    }
        //    mapper.Map(request, clientToUpdate, typeof(ClientUpdateCommand), typeof(ClientTbl));
        //    await context.SaveChangesAsync();


        //}
    }
}