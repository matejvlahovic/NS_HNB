using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NS_HNB_Client.DAL
{
    public class DBInitializer
    {
        public static void Initialize(HNBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
