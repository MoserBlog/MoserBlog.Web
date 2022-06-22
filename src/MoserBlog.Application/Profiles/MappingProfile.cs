using AutoMapper;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;
using MoserBlog.Domain.Blog;

namespace MoserBlog.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogEntry, BlogEntryDetailVm>();

        CreateMap<BlogEntry, BlogEntryOverviewVm>()
            .ForMember(
                dest => dest.Categories,
                m => m.MapFrom(src => string.Join(", ", src.Categories.Select(x => x.Name).ToList())))
            .ForMember(
                dest => dest.AuthorName,
                m => m.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

    }
}
