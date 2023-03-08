using BookStore.DbOperations;

namespace BookStore.Application.AuthorBookOperations.Queries.GetAuthorBooks
{
    public class GetAuthorBooksQuery
    {
        private readonly IBookStoreDbContext _context;
        public int AuthorId;
        public GetAuthorBooksQuery(IBookStoreDbContext context)
        {
            _context = context;
        }

    }
}
