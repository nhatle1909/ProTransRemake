using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class TranslationPriceService : ITranslationPriceService
    {
        private readonly IUnitOfWork _unitofwork;
        public TranslationPriceService(IUnitOfWork unitOfWork) 
        {
            _unitofwork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> AddTranslationPrice(CommandTranslationPriceDTO translationPriceDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = translationPriceDTO.Adapt<TranslationPrice>();
                var result = await _unitofwork.GetRepository<TranslationPrice>().AddItemAsync(newItem);
                await _unitofwork.CommitAsync();
                response.Response(result.Item1,result.Item1,result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> DeleteTranslationPrice(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitofwork.GetRepository<TranslationPrice>().RemoveItemAsync(id);
                await _unitofwork.CommitAsync();
                response.Response(result.Item1, result.Item1,result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<QueryTranslationPriceDTO>>> GetAllTranslationPrices(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryTranslationPriceDTO>> response = new();
            try
            {
                var result = await _unitofwork.GetRepository<TranslationPrice>().GetPagingAsync(searchDTO.searchParams,searchDTO.includeProperties,searchDTO.sortField,
                                                                                                searchDTO.isAsc,searchDTO.pageSize,searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryTranslationPriceDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateTranslationPrice(Guid id, CommandTranslationPriceDTO translationPriceDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = translationPriceDTO.Adapt<TranslationPrice>();
                newItem.Id = id;
                var result = await _unitofwork.GetRepository<TranslationPrice>().UpdateItemAsync(newItem);
                await _unitofwork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
