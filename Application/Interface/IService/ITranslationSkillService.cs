using Application.Common;
using Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.IService
{
    public interface ITranslationSkillService
    {
        public Task<ServiceResponse<IEnumerable<QueryTranslationSkillDTO>>> GetAllTranslationSkills(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> AddTranslationSkill(CommandTranslationSkillDTO translationSkillDTO);
        public Task<ServiceResponse<bool>> UpdateTranslationSkill(Guid id, CommandTranslationSkillDTO translationSkillDTO);
        public Task<ServiceResponse<bool>> DeleteTranslationSkill(Guid id);
        
    }
}
