using AutoMapper;
using Moq;
using MoserBlog.Application.Contracts.Persistence;
using MoserBlog.Application.Features.BlogEntries.Queries.GetBlogEntryOverview;
using MoserBlog.Application.Profiles;
using MoserBlog.Application.UnitTests.Mocks;
using Shouldly;
using Xunit;

namespace MoserBlog.Application.UnitTests.BlogEntries.Queries;

public class GetBlogEntryOverviewQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IBlogEntryRepository> _mockRepository;


    public GetBlogEntryOverviewQueryHandlerTests()
    {
        _mockRepository = BlogEntryRepositoryMock.GetRepository();

        var configProvider = new MapperConfiguration(cnf =>
        {
            cnf.AddProfile<MappingProfile>();
        });

        _mapper = configProvider.CreateMapper();
    }



    [Fact]
    public async Task GetBlogEntryOverviewTest()
    {
        var handler = new GetBlogEntryOverviewQueryHandler(_mockRepository.Object, _mapper);

        var result = await handler.Handle(new GetBlogEntryOverviewQuery(), CancellationToken.None);

        result.ShouldBeOfType<List<BlogEntryOverviewVm>>();

        result.Count.ShouldBe(2);
    }
}
