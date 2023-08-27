
namespace GenericCRUDTemplate.MW.Interfaces
{
    public interface IEntityLogic<TEntity, TCreationDTO, TUpdateDTO, TInfoDTO>
    {
        Task<IEnumerable<TInfoDTO>> GetAll();
        Task<TInfoDTO?> GetById(int id);
        Task<TInfoDTO> Create(TCreationDTO creationDTO);
        Task<TInfoDTO> Update(int id, TUpdateDTO updateDTO);
        Task<bool> Exists(int id);
        Task Delete(int id);
    }
}
