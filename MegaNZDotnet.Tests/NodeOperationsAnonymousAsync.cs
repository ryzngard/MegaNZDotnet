using CG.Web.MegaNZDotnet.Tests.Context;
using Xunit;
using Xunit.Abstractions;

namespace CG.Web.MegaNZDotnet.Tests
{
  [CollectionDefinition(nameof(NodeOperationsAnonymousAsync))]
  public class NodeOperationsAnonymousAsyncTestsCollection : ICollectionFixture<AnonymousAsyncTestContext> { }

  [Collection(nameof(NodeOperationsAnonymousAsync))]
  public class NodeOperationsAnonymousAsync : NodeOperations
  {
    public NodeOperationsAnonymousAsync(AnonymousAsyncTestContext context, ITestOutputHelper testOutputHelper)
      : base(context, testOutputHelper)
    {
    }
  }
}
