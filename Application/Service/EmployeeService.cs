using Application.Common;
using Application.DTO;
using Application.Interface;
using Application.Interface.IService;
using Domain.Entities;
using Mapster;

namespace Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitofwork;
        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitofwork = unitOfWork;
        }
        public async Task<ServiceResponse<bool>> CreateNewEmployee(CommandEmployeeDTO commandEmployeeDTO)
        {
            ServiceResponse<bool> response = new ServiceResponse<bool>();
            try
            {
                var newItem = commandEmployeeDTO.Adapt<Employee>();

                var result = await _unitofwork.GetRepository<Employee>().AddItemAsync(newItem);
                await _unitofwork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<QueryEmployeeDTO>> GetEmployeeInfo(Guid id)
        {
            ServiceResponse<QueryEmployeeDTO> response = new();
            try
            {
                var result = await _unitofwork.GetRepository<Employee>().GetByIdAsync(id);
                var resultDTO = result.Item1.Adapt<QueryEmployeeDTO>();
                response.Response(resultDTO, result.Item2, result.Item3);

            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<QueryEmployeeDTO>>> GetPagingAsync(SearchDTO searchDTO)
        {
            ServiceResponse<IEnumerable<QueryEmployeeDTO>> response = new();
            try
            {
                var result = await _unitofwork.GetRepository<Employee>().GetPagingAsync(searchDTO.searchParams, searchDTO.searchValue, searchDTO.includeProperties,
                                                                                     searchDTO.sortField, searchDTO.pageSize, searchDTO.skip);
                var resultDTO = result.Item1.Adapt<IEnumerable<QueryEmployeeDTO>>();
                response.Response(resultDTO, result.Item2, result.Item3);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> SoftRemoveEmployee(Guid id)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var result = await _unitofwork.GetRepository<Employee>().SoftRemoveItemAsync(id);
                await _unitofwork.CommitAsync();
                response.Response(result.Item1, result.Item1, result.Item2);
            }
            catch (Exception ex)
            {
                response.TryCatchResponse(ex);
            }
            return response;
        }

        public async Task<ServiceResponse<bool>> UpdateEmployeeInfo(Guid id, CommandEmployeeDTO commandEmployeeDTO)
        {
            ServiceResponse<bool> response = new();
            try
            {
                var newItem = commandEmployeeDTO.Adapt<Employee>();
                var result = await _unitofwork.GetRepository<Employee>().UpdateItemAsync(id, newItem);
                await _unitofwork.CommitAsync();
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
                var result = await _unitofwork.GetRepository<Employee>().CountAsync(countDTO.searchParams,countDTO.searchValue, countDTO.pageSize);
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
