using Person.Application.Generic.Dtos;
using Person.Domain.Entities;

namespace Person.Application.Generic.Interfaces
{
    public interface IBaseCrudHandler<TDto,ResponseDto, TEntity> where TDto : BaseDto where TEntity : BaseEntity
    {
        Task<IQueryable<TEntity>> Query();
        Task<ResponseDto> GetById(int id);
        Task<TDto> Create(ResponseDto dto);
        Task<ResponseDto> Update(TDto dto);
        Task<ResponseDto> Update(int id, TDto dto);
        Task<bool> Delete(int id);
    }
}
