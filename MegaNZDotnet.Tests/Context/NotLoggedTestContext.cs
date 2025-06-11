using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CG.Web.MegaNZDotnet.Tests.Context
{

  [CollectionDefinition(nameof(NotLoggedTestContext))]
  public class NotLoggedTestsCollection : ICollectionFixture<NotLoggedTestContext> { }

  public class NotLoggedTestContext : TestContext
  {
    protected override void ConnectClient(IMegaApiClient client)
    {
    }

    protected override IEnumerable<string> GetProtectedNodes()
    {
      return Enumerable.Empty<string>();
    }

    protected override IEnumerable<string> GetPermanentNodes()
    {
      return Enumerable.Empty<string>();
    }
  }
}
