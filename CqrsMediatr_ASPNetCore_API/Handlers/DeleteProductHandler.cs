using CqrsMediatr_ASPNetCore_API.Commands;
using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly FakeDataStore _fakeDataStore;
        public DeleteProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.DeleteProduct(request.id);
        }
    }
}
