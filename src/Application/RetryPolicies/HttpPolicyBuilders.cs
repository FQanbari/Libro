using Polly;
using Polly.Extensions.Http;

namespace Application.RetryPolicies;

public static class HttpPolicyBuilders
{
    public static PolicyBuilder<HttpResponseMessage> GetBaseBuilder()
    {
        return HttpPolicyExtensions.HandleTransientHttpError();
    }
    
}
