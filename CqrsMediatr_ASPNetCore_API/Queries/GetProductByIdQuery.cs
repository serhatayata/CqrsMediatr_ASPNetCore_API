using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Queries
{
    public record GetProductByIdQuery(int Id):IRequest<Product>
    {

    }
}
