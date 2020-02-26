using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface IFilialiManager
    {
        Task<IEnumerable<Filiali>> GetAllFilialiByClientId(string clientId);
    }
}
