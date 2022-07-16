using System.Text.RegularExpressions;
using Microsoft.Extensions.Options;
using MoserBlog.Web.Configurations;
using MoserBlog.Web.Services.Interfaces;

namespace MoserBlog.Web.Services;

public class MediaService : IMediaService
{
    public static readonly Regex ValidationRegex = new("", RegexOptions.Compiled | RegexOptions.CultureInvariant);

    private readonly IConfiguration _configuration;

    public MediaService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetMediaUrl(string mediaName)
    {
        if (!ValidationRegex.IsMatch(mediaName))
        {
            throw new ArgumentException($"{mediaName} is not a valid MediaName", nameof(mediaName));
        }

        return $"{_configuration["MediaToolUrl"]}/{mediaName}";
    }
}
