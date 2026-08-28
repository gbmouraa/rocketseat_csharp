using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestExpenseJson, Expense>();
            CreateMap<RegisterUserJson, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<Expense, ResponseRegisterExpenseJson>();
            CreateMap<Expense, ShortExpenseJson>();
            CreateMap<Expense, ResponseFullExpenseJson>();
        }
    }
}
