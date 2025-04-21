using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class QueryTranslationSkillDTO
    {
        public string? CertificateUrl { get; set; }
        public required string Language { get; set; }
    }
    public class CommandTranslationSkillDTO
    {
        public string? CertificateUrl { get; set; }
        public required string Language { get; set; }
      
        public Guid TranslatorId { get; set; }
    }
}
