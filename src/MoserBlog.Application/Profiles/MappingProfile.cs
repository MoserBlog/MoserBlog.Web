using AutoMapper;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;
using MoserBlog.Domain.Blog;

namespace MoserBlog.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogEntry, BlogEntryDetailVm>().ReverseMap();
    }
}
