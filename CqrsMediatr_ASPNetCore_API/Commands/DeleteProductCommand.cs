using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Commands
{
    public record DeleteProductCommand(int id) : IRequest<bool>;
}
