using Application.DTO;
using Domain.Entities;
using Mapster;

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

            config.NewConfig<Agency, QueryAgencyDTO>();
            config.NewConfig<Agency, CommandAgencyDTO>();

            config.NewConfig<Order, QueryOrderDTO>();
            config.NewConfig<Order, CommandOrderDTO>();

            config.NewConfig<Distance, QueryDistanceDTO>();
            config.NewConfig<Distance, CommandDistanceDTO>();

            config.NewConfig<Transaction, QueryTransactionDTO>();
            config.NewConfig<Transaction, CommandTransactionDTO>();
        }
    }
}
