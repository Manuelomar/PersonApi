using Person.Application.Generic.Dtos;
using Person.Application.Generic.Interfaces;
using Person.Domain.Entities;
using AutoMapper;

namespace Person.Application.Generic.Handlers
{
    public class BaseCrudHandler<TDto, ResponseDto, TEntity> : IBaseCrudHandler<TDto, ResponseDto, TEntity> 
        where TDto : BaseDto where TEntity : BaseEntity
    {

        protected readonly IBaseCrudService<TEntity> _crudService;
        protected readonly IMapper _mapper;
        
        public BaseCrudHandler(IBaseCrudService<TEntity> crudService, IMapper mapper)
        {
            _crudService = crudService;
            _mapper = mapper;
        }

        public virtual Task<IQueryable<TEntity>> Query()
        {
            return Task.FromResult(_crudService.Query());
        }
        public virtual async Task<List<TEntity>> Get(int top = 50)
        {
            var dto = await _crudService.Get(top);
            return dto;
        }
        public virtual async Task<ResponseDto> GetById(int id)
        {
            var entity = await _crudService.GetById(id);
            var dto = _mapper.Map<ResponseDto>(entity);
            return dto;
        }

        public virtual async Task<TDto> Create(ResponseDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _crudService.Create(entity);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<ResponseDto> Update(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _crudService.Update(entity);
            return _mapper.Map<ResponseDto> (entity);
        }

        public virtual async Task<ResponseDto> Update(int id, TDto dto)
        {
            var BaseEntity = await _crudService.GetById(id);
            var entity = _mapper.Map<TEntity>(dto);
            entity = await _crudService.Update(id, entity);
            return _mapper.Map<ResponseDto>(entity);
        }

        public virtual async Task<bool> Delete(int id)
        {
            return await _crudService.Delete(id);
        }
    }
}
