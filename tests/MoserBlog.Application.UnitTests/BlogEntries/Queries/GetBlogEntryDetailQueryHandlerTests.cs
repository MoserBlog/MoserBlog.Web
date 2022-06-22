using AutoMapper;
using Moq;
using MoserBlog.Application.Contracts.Persistence;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryDetail;
using MoserBlog.Application.Profiles;
using MoserBlog.Application.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace MoserBlog.Application.UnitTests.BlogEntries.Queries;

public class GetBlogEntryDetailQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IBlogEntryRepository> _mockRepository;


    public GetBlogEntryDetailQueryHandlerTests()
    {
        _mockRepository = BlogEntryRepositoryMock.GetRepository();

        var configProvider = new MapperConfiguration(cnf =>
        {
            cnf.AddProfile<MappingProfile>();
        });

        _mapper = configProvider.CreateMapper();
    }



    [Fact]
    public async Task GetBlogEntryDetailTest()
    {
        var handler = new GetBlogEntryDetailQueryHandler(_mockRepository.Object, _mapper);

        var result = await handler.Handle(
            new GetBlogEntryDetailQuery() { UrlName = "second-blog-entry" },
            CancellationToken.None);

        result.ShouldBeOfType<BlogEntryDetailVm>();
    }
}
