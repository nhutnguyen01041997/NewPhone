using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewPhone.Models
{
    public interface INewPhoneRepository
    {
        IQueryable<SMartPhone> SMartPhones { get; }
    }
}
