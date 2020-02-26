using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Talent.DataModel.Models;

namespace Talent.BLL.Repositories
{
    public interface ITitoliManager
    {
        Task<IEnumerable<Titoli>> GetAllTitoliByClientId(string clientId);

    }
}
