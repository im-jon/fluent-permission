using MediatR;

namespace FluentPermission.MediatR.Tests;

public class RequestTest
{
    private class TestRequest : IRequest
    {
        internal class Authorization : AbstractRequestAuthorization<TestRequest>
        {
            public Authorization()
            {
                this.RequirePermission(Permission.CreateNew("test-permission"));
            }
        }
    }
    
    [Fact]
    public void Test1()
    {
    }
}