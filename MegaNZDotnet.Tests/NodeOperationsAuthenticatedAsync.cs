using MegaNZDotnet.Tests.Context;

using Xunit;
using Xunit.Abstractions;

namespace MegaNZDotnet.Tests;

[Collection(nameof(AuthenticatedTestContext))]
public class NodeOperationsAuthenticatedAsync : NodeOperationsAuthenticated
{
    public NodeOperationsAuthenticatedAsync(AuthenticatedAsyncTestContext context, ITestOutputHelper testOutputHelper)
      : base(context, testOutputHelper)
    {
    }
}