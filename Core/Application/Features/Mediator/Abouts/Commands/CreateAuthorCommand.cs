using MediatR;

namespace Application.Features.Mediator.Abouts.Commands
{
    public class CreateAboutCommand:IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
