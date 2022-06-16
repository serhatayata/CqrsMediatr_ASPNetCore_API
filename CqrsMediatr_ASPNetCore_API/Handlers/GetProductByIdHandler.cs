using CqrsMediatr_ASPNetCore_API.Models;
using CqrsMediatr_ASPNetCore_API.Queries;
using MediatR;

namespace CqrsMediatr_ASPNetCore_API.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FakeDataStore _fakeDataStore;

        public GetProductByIdHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _fakeDataStore.GetProductById(request.Id);
        }
    }
}
