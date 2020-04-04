using System;
using System.Collections.Generic;
using System.Text;
using KoohTajrobe.DataAccess;

namespace KoohTajrobe.Repository
{
    public class BaseRepository
    {
        public KoohTajrobeDbContext KoohTajrobeDbContext { get; set; }

        public BaseRepository(KoohTajrobeDbContext koohTajrobeDbContext)
        {
            KoohTajrobeDbContext = koohTajrobeDbContext;
        }

    }
}
