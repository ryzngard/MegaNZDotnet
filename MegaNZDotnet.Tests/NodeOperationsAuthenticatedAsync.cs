using CG.Web.MegaNZDotnet.Tests.Context;
using Xunit;
using Xunit.Abstractions;

namespace CG.Web.MegaNZDotnet.Tests
{
  [Collection(nameof(AuthenticatedTestContext))]
  public class NodeOperationsAuthenticatedAsync : NodeOperationsAuthenticated
  {
    public NodeOperationsAuthenticatedAsync(AuthenticatedAsyncTestContext context, ITestOutputHelper testOutputHelper)
      : base(context, testOutputHelper)
    {
    }
  }
}
