using Service.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Domain
{
    public class ClientTbl: EntityBase
    {
        public string Names { get; set; } = null!;
        
        public string LastNames { get; set; } = null!;
        
        //[Date]
        public DateTime BirthDate { get; set; }
        
        public string Cuit { get; set; } = null!;
        
        public string Address { get; set; } = null!;
        
        public string CelularPhone { get; set; } = null!;
        
        //[Email]
        public string Email { get; set; } = null!;

    }
}
