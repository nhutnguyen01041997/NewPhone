using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhone.Models
{
    public class EFNewPhoneRepository : INewPhoneRepository
    {
        private NewPhoneDbContext context;
        public EFNewPhoneRepository(NewPhoneDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<SMartPhone> SMartPhones => context.SMartPhones;
    }
}
