using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Notifications
{
    public record ProductAddedNotification(Product product):INotification;
    
}
