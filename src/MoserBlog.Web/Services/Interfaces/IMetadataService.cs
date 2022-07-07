namespace MoserBlog.Web.Services.Interfaces;

public interface IMetadataService
{
    string GetPageTitle(string? pageTitle);
    string GetPageDescription(string? pageDescription);
    string GetRobotsValue();
}
