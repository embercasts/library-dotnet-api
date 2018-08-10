using JsonApiDotNetCore.Controllers;
using JsonApiDotNetCore.Services;
using LibraryApi.Models;
using Microsoft.Extensions.Logging;

namespace LibraryApi.Domain.Reviews
{
  public class ReviewsController : JsonApiController<Review>
  {
    public ReviewsController(
        IJsonApiContext jsonApiContext,
        IResourceService<Review> resourceService,
        ILoggerFactory loggerFactory
    ) : base(jsonApiContext, resourceService, loggerFactory)
    { }
  }
}
