using Application.Enums;
using Application.Features.Mediator.Abouts.Commands;
using Application.Features.Mediator.Abouts.Results;
using Application.Features.Mediator.Authors.Commands;
using Application.Features.Mediator.Authors.Results;
using Application.Features.Mediator.Banners.Commands;
using Application.Features.Mediator.Banners.Results;
using Application.Features.Mediator.Barrows.Commands;
using Application.Features.Mediator.Barrows.Results;
using Application.Features.Mediator.Books.Commands;
using Application.Features.Mediator.Books.Results;
using Application.Features.Mediator.Categories.Commands;
using Application.Features.Mediator.Categories.Results;
using Application.Features.Mediator.Features.Commands;
using Application.Features.Mediator.Features.Results;
using Application.Features.Mediator.Testimonials.Commands;
using Application.Features.Mediator.Testimonials.Results;
using Application.Features.Mediator.Users.Commands;
using Application.Features.Mediator.Users.Results;
using AutoMapper;
using Domain.Entities;

namespace Application.MappersProfiles
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Feature,CreateFeatureCommand>().ReverseMap();
            CreateMap<Feature,UpdateFeatureCommand>().ReverseMap();
            CreateMap<Feature,GetFeatureQueryResult>().ReverseMap();
            CreateMap<Feature,GetFeatureByIdQueryResult>().ReverseMap();

            CreateMap<Testimonial, CreateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialCommand>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialQueryResult>().ReverseMap();

            CreateMap<Author, CreateAuthorCommand>().ReverseMap();
            CreateMap<Author, UpdateAuthorCommand>().ReverseMap();
            CreateMap<Author, GetAuthorByIdQueryResult>().ReverseMap();
            CreateMap<Author, GetAuthorQueryResult>().ReverseMap();

            CreateMap<Banner, CreateBannerCommand>().ReverseMap();
            CreateMap<Banner, UpdateBannerCommand>().ReverseMap();
            CreateMap<Banner, GetBannerQueryResult>().ReverseMap();

            CreateMap<Barrow, CreateBarrowCommand>().ReverseMap();
            CreateMap<Barrow, GetBarrowByIdQueryResult>().ReverseMap();
            CreateMap<Barrow, GetBarrowQueryResult>().ReverseMap();

            CreateMap<Book, CreateBookCommand>().ReverseMap();
            CreateMap<Book, UpdateBookCommand>().ReverseMap();
            CreateMap<Book, GetBookByIdQueryResult>().ReverseMap();
            CreateMap<Book, GetBookQueryResult>().ReverseMap();

            CreateMap<Category, CreateCategoryCommand>().ReverseMap();
            CreateMap<Category, UpdateCategoryCommand>().ReverseMap();
            CreateMap<Category, GetCategoryByIdQueryResult>().ReverseMap();
            CreateMap<Category, GetCategoryQueryResult>().ReverseMap();

            //CreateMap<User, CreateUserCommand>().ReverseMap()
            //   .ForMember(dest => dest.Rol, opt => opt.MapFrom(src => Rol.kullanıcı));

            CreateMap<User, CreateUserCommand>().ReverseMap()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Rol.Üye));
            CreateMap<User, UpdateUserCommand>().ReverseMap()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => Rol.Üye));
            CreateMap<User, GetUserByIdQueryResult>().ReverseMap();
            CreateMap<User, GetUserQueryResult>().ReverseMap();

            CreateMap<About, CreateAboutCommand>().ReverseMap();
            CreateMap<About, UpdateAboutCommand>().ReverseMap();
            CreateMap<About, GetAboutByIdQueryResult>().ReverseMap();
            CreateMap<About, GetAboutQueryResult>().ReverseMap();
        }
    }
}
