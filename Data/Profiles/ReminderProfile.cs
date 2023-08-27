using AutoMapper;
using GenericCRUDTemplate.Data.DataTransferObjects;
using GenericCRUDTemplate.Data.Models;

public class ReminderProfile : Profile
{
    public ReminderProfile()
    {
        CreateMap<Reminder, ReminderInfoDTO>();
        CreateMap<ReminderCreationDTO, Reminder>();
        CreateMap<ReminderUpdateDTO, Reminder>();
    }
}