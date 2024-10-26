using MediatR;

namespace Application.Features.Mediator.Authors.Commands
{
    public class CreateAuthorCommand:IRequest
    {
        public string Name { get; set; }
    }
}
