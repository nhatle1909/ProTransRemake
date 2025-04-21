using Application.DTO;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration
{
    public class MapperProfile : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<User, QueryUserDTO>();
            config.NewConfig<User, CommandUserDTO>();

            config.NewConfig<Employee, QueryEmployeeDTO>();
            config.NewConfig<Employee, CommandEmployeeDTO>();

            config.NewConfig<TranslationSkill, QueryTranslationSkillDTO>();
            config.NewConfig<TranslationSkill, CommandTranslationSkillDTO>();

            config.NewConfig<TranslationPrice, QueryTranslationPriceDTO>();
            config.NewConfig<TranslationPrice, CommandTranslationPriceDTO>();
        }
    }
}
