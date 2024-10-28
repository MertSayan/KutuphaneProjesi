using MediatR;

namespace Application.Features.Mediator.Abouts.Commands
{
    public class RemoveAboutCommand:IRequest
    {
        public int Id { get; set; }

        public RemoveAboutCommand(int ıd)
        {
            Id = ıd;
        }
    }
}
