using AutoMapper;
using Microsoft.EntityFrameworkCore;
using GenericCRUDTemplate.MW.Exceptions;
using GenericCRUDTemplate.MW.Interfaces;

namespace GenericCRUDTemplate.MW.BusinessLogic
{
    public class EntityLogic<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO> : IEntityLogic<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO>
        where TEntity : class, IEntityWithId
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public EntityLogic(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TInfoDTO>> GetAll()
        {
            IQueryable<TEntity> entities = _dbContext.Set<TEntity>();
            return await entities.Select(x => _mapper.Map<TInfoDTO>(x)).ToListAsync();
        }

        public async Task<TInfoDTO?> GetById(int id)
        {
            TEntity? entity = await _dbContext.Set<TEntity>().FindAsync(id);
            return _mapper.Map<TInfoDTO>(entity);
        }

        public async Task<TInfoDTO> Create(TCreationDTO creationDTO)
        {
            TEntity entityToCreate = _mapper.Map<TEntity>(creationDTO);
            var addedEntity = await _dbContext.Set<TEntity>().AddAsync(entityToCreate);
            await _dbContext.SaveChangesAsync();

            TInfoDTO createdEntityDTO = _mapper.Map<TInfoDTO>(addedEntity.Entity);
            return createdEntityDTO;
        }

        public async Task<TInfoDTO> Update(int id, TUpdateDTO updateDTO)
        {
            TEntity? existingEntity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (existingEntity == null)
            {
                throw new EntityNotFoundException();
            }

            _mapper.Map(updateDTO, existingEntity); // Update the properties of the existing entity
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TInfoDTO>(existingEntity);
        }

        public async Task<bool> Exists(int id)
        {
            return await _dbContext.Set<TEntity>().AnyAsync(x => x.Id == id); 
        }

        public async Task Delete(int id)
        {
            TEntity? entityToDelete = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entityToDelete is null)
            {
                throw new EntityNotFoundException($"Entity with ID {id} not found.");
            }

            _dbContext.Set<TEntity>().Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
