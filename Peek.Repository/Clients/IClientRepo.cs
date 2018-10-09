using Peek.Models.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peek.Repository.Clients
{
    public interface IClientRepo : IRepo<ClientModel>
    {
        IEnumerable<ClientModel> SelectAscending(int skip, int take);
        IEnumerable<ClientModel> SelectDescending(int skip, int take);
    }
}
