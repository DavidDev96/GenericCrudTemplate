using GenericCRUDTemplate.Data.DataTransferObjects;
using GenericCRUDTemplate.Data.Models;
using GenericCRUDTemplate.MW.BusinessLogic;

namespace GenericCRUDTemplate.MW.Controllers
{
    public class ReminderController : BaseController<Reminder, ReminderCreationDTO, ReminderUpdateDTO, ReminderInfoDTO>
    {
        public ReminderController(EntityLogic<Reminder, ReminderCreationDTO, ReminderUpdateDTO, ReminderInfoDTO> entityLogic)
            : base(entityLogic)
        {
        }
    }
}