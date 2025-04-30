using Application.Common;
using Application.DTO;

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
