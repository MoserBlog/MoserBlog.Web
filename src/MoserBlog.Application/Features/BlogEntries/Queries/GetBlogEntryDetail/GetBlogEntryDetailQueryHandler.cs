using AutoMapper;
using MediatR;
using MoserBlog.Application.Contracts.Persistence;

namespace MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;

public class GetBlogEntryDetailQueryHandler : IRequestHandler<GetBlogEntryDetailQuery, BlogEntryDetailVm>
{
    private readonly IBlogEntryRepository _blogEntryRepository;
    private readonly IMapper _mapper;

    public GetBlogEntryDetailQueryHandler(
        IBlogEntryRepository blogEntryRepository,
        IMapper mapper)
    {
        _blogEntryRepository = blogEntryRepository;
        _mapper = mapper;
    }


    public async Task<BlogEntryDetailVm> Handle(GetBlogEntryDetailQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<BlogEntryDetailVm>(await _blogEntryRepository.FindActiveByUrlNameAsync(request.UrlName));
    }
}
