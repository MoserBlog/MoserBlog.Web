<p align="center">
    <img src="https://raw.githubusercontent.com/MoserBlog/.github/main/images/github-titleimages/web-titleimage.png">
</p>


# Migrations
Migrations needs to be executed in Web-Project with an additional project-Parameter that targets the Persistence-Project where ApplicationDbContext is located.
```
dotnet ef migrations add "[MESSAGE]" --project ../MoserBlog.Persistence
```