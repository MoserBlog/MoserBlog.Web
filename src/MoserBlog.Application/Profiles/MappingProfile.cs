using AutoMapper;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;
using MoserBlog.Domain.Blog;

namespace MoserBlog.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BlogEntry, BlogEntryDetailVm>().ReverseMap();
        CreateMap<BlogEntry, BlogEntryOverviewVm>().ReverseMap();
    }
}
