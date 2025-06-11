using System.Collections.Generic;

using MegaNZDotnet.Interface;

using Xunit.Abstractions;

namespace MegaNZDotnet.Tests.Context;

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