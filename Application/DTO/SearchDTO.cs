using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
     public class SearchDTO
    {
        public Dictionary<string, string> searchParams { get; set; }
        public string? includeProperties { get; set; }
        public string? sortField { get; set; }
        public bool isAsc { get; set; } = false;
        public int pageSize { get; set; }
        public int skip { get; set; }
    }
}
