using MediatR;

namespace Application.Features.Mediator.Authors.Commands
{
    public class RemoveAuthorCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAuthorCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
