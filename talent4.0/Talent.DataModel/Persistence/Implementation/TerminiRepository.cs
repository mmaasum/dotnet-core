using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;
using Talent.DataModel.DataModels;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TerminiRepository :Repository<Termini>, ITerminiRepository
    {
        public TerminiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }


        public async Task<IEnumerable<string>> GetAllKeywordLanguageAsync()
        {
            var languages = await Context.Termini
                .Where(a => !String.IsNullOrEmpty(a.TerLingua))
                .Select(a => a.TerLingua)
                .Distinct()
                .ToListAsync();

            return languages;
        }

        public async Task<IEnumerable<LastAnalysisDto>> GetLastAnalysisInfoDal(string cliId, string uteId)
        {
            //var languages = await Context.Termini
            //    .Where(a => !String.IsNullOrEmpty(a.TerLingua))
            //    .Select(a => a.TerLingua)
            //    .Distinct()
            //    .ToListAsync();

            return null;
        }
    }
}