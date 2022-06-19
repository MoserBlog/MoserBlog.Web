using AutoMapper;
using MediatR;
using MoserBlog.Application.Contracts.Persistence;

namespace MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;

public class GetBlogEntryOverviewQueryHandler : IRequestHandler<GetBlogEntryOverviewQuery, List<BlogEntryOverviewVm>>
{
    private readonly IBlogEntryRepository _blogEntryRepository;
    private readonly IMapper _mapper;

    public GetBlogEntryOverviewQueryHandler(
        IBlogEntryRepository blogEntryRepository,
        IMapper mapper)
    {
        _blogEntryRepository = blogEntryRepository;
        _mapper = mapper;
    }


    public async Task<List<BlogEntryOverviewVm>> Handle(GetBlogEntryOverviewQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<List<BlogEntryOverviewVm>>(await _blogEntryRepository.GetLatestForOverviewAsync(request.AmountOfElements));
    }
}
