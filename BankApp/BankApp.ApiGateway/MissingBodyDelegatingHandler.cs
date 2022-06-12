using MediaTypeHeaderValue = System.Net.Http.Headers.MediaTypeHeaderValue;

namespace BankApp.ApiGateway;

public class MissingBodyDelegatingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MissingBodyDelegatingHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext.Request.ContentType != null && request.Content == null)
        {
            if (httpContext.Request.Body.CanSeek)
            {
                httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            }

            using (var body = new MemoryStream())
            {
                await httpContext.Request.Body.CopyToAsync(body, cancellationToken);

                request.Content = new ByteArrayContent(body.ToArray())
                {
                    Headers =
                    {
                        ContentType = new MediaTypeHeaderValue(httpContext.Request.ContentType)
                    }
                };
            }
        }

        return await base.SendAsync(request, cancellationToken);
    }
}