using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TranslationPrice : BaseEntity
    {
        public required string  LanguageName {  get; set; }
        public required decimal Price { get; set; }
    }
}
