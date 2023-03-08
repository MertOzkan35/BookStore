using FluentValidation;
using System;

namespace BookStore.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator <UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
            //RuleFor(command => command.Model.Name).MinimumLength(2);
            //RuleFor(command => command.Model.Lastname).MinimumLength(2);
            RuleFor(command => command.Model.DateOfBirth).LessThan(DateTime.Now.Date);
        }
    }
}
