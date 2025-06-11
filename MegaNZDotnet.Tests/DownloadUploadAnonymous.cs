using MegaNZDotnet.Tests.Context;
using Xunit;
using Xunit.Abstractions;

namespace MegaNZDotnet.Tests;

[CollectionDefinition(nameof(DownloadUploadAnonymous))]
public class DownloadUploadAnonymousTestsCollection : ICollectionFixture<AnonymousTestContext> { }

[Collection(nameof(DownloadUploadAnonymous))]
public class DownloadUploadAnonymous : DownloadUpload
{
  public DownloadUploadAnonymous(AnonymousTestContext context, ITestOutputHelper testOutputHelper)
    : base(context, testOutputHelper)
  {
  }
}
