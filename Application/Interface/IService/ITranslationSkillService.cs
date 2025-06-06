using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface ITranslationSkillService
    {
        public Task<ServiceResponse<IEnumerable<QueryTranslationSkillDTO>>> GetPagingAsync(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> AddTranslationSkill(CommandTranslationSkillDTO translationSkillDTO);
        public Task<ServiceResponse<bool>> UpdateTranslationSkill(Guid id, CommandTranslationSkillDTO translationSkillDTO);
        public Task<ServiceResponse<bool>> DeleteTranslationSkill(Guid id);
        Task<ServiceResponse<long>> CountAsync(CountDTO countDTO);
    }
}
