using CqrsMediatr_ASPNetCore_API.Commands;
using CqrsMediatr_ASPNetCore_API.Models;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public UpdateProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.UpdateProduct(request.product);
        }
    }
}
