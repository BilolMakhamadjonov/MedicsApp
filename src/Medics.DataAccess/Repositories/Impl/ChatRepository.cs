using Medics.Core.Entities;
using Medics.DataAccess.Data;

namespace Medics.DataAccess.Repositories.Impl;

public class ChatRepository : BaseRepository<Chat>, IChatRepository
{
    public ChatRepository(AppDbContext context) : base(context) { }
}
