using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class CartRepository : BaseRepository<Cart>, ICartRepository
{
    public CartRepository(AppDbContext context) : base(context) { }
}
