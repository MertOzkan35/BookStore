using AutoMapper;
using BookStore.DbOperations;
using System;
using System.Linq;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDbContext _context;
        public UpdateAuthorModel Model { get; set; }
        public int AuthorId;
        public UpdateAuthorCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x => x.Id == AuthorId);
            if (author is null)
                throw new InvalidOperationException("Güncellenecek yazar bulunamadı");

            author.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? author.Name : Model.Name;
            author.Lastname = String.IsNullOrEmpty(Model.Lastname.Trim()) ? author.Lastname : Model.Lastname;
            author.DateOfBirth = Model.DateOfBirth != default ? Model.DateOfBirth : author.DateOfBirth;

            _context.SaveChanges();

        }
        //genre.Name = String.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name; 
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
