namespace Application.RetryPolicies.Config;

public interface ICircuitBreakerPolicyConfig
{
    int RetryCount { get; set; }
    int BreakDuration { get; set; }
}

public interface IRetryPolicyConfig
{
    int RetryCount { get; set; }
}

public class PolicyConfig : ICircuitBreakerPolicyConfig, IRetryPolicyConfig
{
    public int RetryCount { get; set; }
    public int BreakDuration { get; set; }
}