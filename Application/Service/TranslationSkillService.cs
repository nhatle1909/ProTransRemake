using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class TranslationSkillService : ITranslationSkillService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TranslationSkillService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddTranslationSkill(CommandTranslationSkillDTO translationSkillDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = translationSkillDTO.Adapt<TranslationSkill>();
                var result = await _unitOfWork.GetRepository<TranslationSkill>().AddItemAsync(newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteTranslationSkill(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<TranslationSkill>().RemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<QueryTranslationSkillDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryTranslationSkillDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<TranslationSkill>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties, searchDTO.sortField,
                                                                                         searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryTranslationSkillDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateTranslationSkill(Guid id, CommandTranslationSkillDTO translationSkillDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = translationSkillDTO.Adapt<TranslationSkill>();
                var result = await _unitOfWork.GetRepository<TranslationSkill>().UpdateItemAsync(id, newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<long>> CountAsync(CountDTO countDTO)
        {
            ServiceResponse<long> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<TranslationSkill>().CountAsync(countDTO.searchParams, countDTO.searchValue);
                response.Response(result, result > 0, string.Empty);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
