using Application.Common;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IService
{
    public interface ITranslationPriceService
    {
        public Task<ServiceResponse<IEnumerable<QueryTranslationPriceDTO>>> GetPagingAsync(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> AddTranslationPrice(CommandTranslationPriceDTO translationPriceDTO);
        public Task<ServiceResponse<bool>> UpdateTranslationPrice(Guid id, CommandTranslationPriceDTO translationPriceDTO);
        public Task<ServiceResponse<bool>> DeleteTranslationPrice(Guid id);
    }
}
