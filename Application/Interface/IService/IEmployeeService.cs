﻿using Application.Common;
using Application.DTO;

namespace Application.Interface.IService
{
    public interface IEmployeeService
    {
        public Task<ServiceResponse<bool>> CreateNewEmployee(CommandEmployeeDTO commandEmployeeDTO);
        public Task<ServiceResponse<QueryEmployeeDTO>> GetEmployeeInfo(Guid id);
        public Task<ServiceResponse<bool>> UpdateEmployeeInfo(Guid id, CommandEmployeeDTO commandEmployeeDTO);
        public Task<ServiceResponse<IEnumerable<QueryEmployeeDTO>>> GetPagingAsync(SearchDTO searchDTO);
        public Task<ServiceResponse<bool>> SoftRemoveEmployee(Guid id);
        Task<ServiceResponse<long>> CountAsync(CountDTO countDTO);
    }
}
