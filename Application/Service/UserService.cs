﻿using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapster;
        public UserService(IUnitOfWork unitOfWork,IMapper mapster)
        {
            _unitOfWork = unitOfWork;
            _mapster = mapster;
        }
        public async Task<ServiceResponse<IEnumerable<QueryUserDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryUserDTO>> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<User>().GetPagingAsync(searchDTO.searchParams, searchDTO.includeProperties,
                                                                                    searchDTO.sortField, searchDTO.isAsc, searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryUserDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch ( Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> CreateGuestUser(CommandUserDTO commandUserDTO)
        {
            ServiceResponse<bool> response= new();
            try
            {
                var newGuestUser = commandUserDTO.Adapt<User>();
                var result = await _unitOfWork.GetRepository<User>().AddItemAsync(newGuestUser);
               await  _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch(Exception ex)
            {
                response.TryCatchResponse(ex);
                
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> SoftRemoveUser(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<User>().SoftRemoveItemAsync(id);
               await  _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
        public async Task<ServiceResponse<bool>> UpdateProfile(Guid id,CommandUserDTO commandUserDTO) 
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = commandUserDTO.Adapt<User>();
                newItem.Id = id;
                var result = await _unitOfWork.GetRepository<User>().UpdateItemAsync(newItem);
               await  _unitOfWork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<QueryUserDTO>> GetUserInfo(Guid id)
        {
            ServiceResponse<QueryUserDTO> response = new();
            try
            {
                var result = await _unitOfWork.GetRepository<User>().GetByIdAsync(id);
                var resultDTO = result.Item1.Adapt<QueryUserDTO>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch(Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }
    }
}
