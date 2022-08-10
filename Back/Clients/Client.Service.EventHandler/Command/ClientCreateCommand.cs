using Client.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Service.EventHandler.Command
{
    public class ClientCreateCommand: IRequest<ClientTbl>
    {
        public int Id { get; set; }
        public string Names { get; set; } = null!;
        public string LastNames { get; set; } = null!;
        public string BirthDate { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string CelularPhone { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
