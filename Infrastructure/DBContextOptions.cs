using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class DBContextOptions
    {
        public required string ConnectionString { get; set; }
    }
}
