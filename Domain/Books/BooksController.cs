using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApi.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApi.Domain.Books
{
  public class BooksController : JsonApiController<Book>
  {
    public BooksController(
        IJsonApiContext jsonApiContext,
        IResourceService<Book> resourceService,
        ILoggerFactory loggerFactory
    ) : base(jsonApiContext, resourceService, loggerFactory)
    { }
  }
}
