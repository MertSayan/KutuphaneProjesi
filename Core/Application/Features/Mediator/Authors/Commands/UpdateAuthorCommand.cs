using MediatR;

namespace Application.Features.Mediator.Authors.Commands
{
    public class UpdateAuthorCommand:IRequest
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
    }
}
