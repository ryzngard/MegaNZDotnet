using System.Collections.Generic;
using Xunit.Abstractions;

namespace CG.Web.MegaNZDotnet.Tests.Context
{
  public interface ITestContext
  {
    IMegaApiClient Client { get; }

    IWebClient WebClient { get; }

    Options Options { get; }

    IEnumerable<string> ProtectedNodes { get; }

    IEnumerable<string> PermanentRootNodes { get; }

    void SetLogger(ITestOutputHelper testOutputHelper);

    void ClearLogger();
  }
}
