using CqrsMediatr_ASPNetCore_API.Models;
using CqrsMediatr_ASPNetCore_API.Notifications;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Handlers
{
    public class CacheInvalidationHandler:INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;
        public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EventOccured(notification.product, "Cache Invalidated");
            await Task.CompletedTask;
        }
    }
}
