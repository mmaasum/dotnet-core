﻿using System;
using System.Collections.Generic;
using System.Text;
using Talent.DataModel.Models;
using Talent.DataModel.Repositories;

namespace Talent.DataModel.Persistence.Implementation
{
    public class FilialiRepository : Repository<Filiali>, IFilialiRepository
    {
        public FilialiRepository(ApplicationDbContext context) : base(context)
        {

        }

        public ApplicationDbContext Context
        {
            get { return _context as ApplicationDbContext; }
        }
    }
}
