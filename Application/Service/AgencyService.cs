﻿using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class AgencyService : IAgencyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AgencyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<bool>> CreateAgency(CommandAgencyDTO commandAgencyDTO)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var newItem = commandAgencyDTO.Adapt<Agency>();
                var result = await _unitOfWork.GetRepository<Agency>().AddItemAsync(newItem);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<QueryAgencyDTO>>> GetPagingAgencies(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryAgencyDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Agency>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties,
                                                                                     searchDTO.sortField, searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryAgencyDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> SoftRemoveAgency(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Agency>().SoftRemoveItemAsync(id);
                await _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);

            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateAgency(Guid id, CommandAgencyDTO commandAgencyDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = commandAgencyDTO.Adapt<Agency>();
                var result = await _unitOfWork.GetRepository<Agency>().UpdateItemAsync(id, newItem);
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
            ServiceResponse<long> serviceResponse = new();
            try
            {
                var result = await _unitOfWork.GetRepository<Agency>().CountAsync(countDTO.searchParams, countDTO.searchValue, countDTO.pageSize);
                serviceResponse.Response(result, result > 0, string.Empty);
            }
            catch (Exception ex)
            {
                serviceResponse.TryCatchResponse(ex);
            }
            return serviceResponse;

        }
    }
}
