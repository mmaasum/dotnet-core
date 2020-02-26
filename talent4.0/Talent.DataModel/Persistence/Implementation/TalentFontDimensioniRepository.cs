﻿using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class TalentFontDimensioniRepository : Repository<TalentFontDimensioni>, ITalentFontDimensioniRepository
    {
        public TalentFontDimensioniRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}