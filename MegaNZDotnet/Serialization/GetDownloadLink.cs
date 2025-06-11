
using MegaNZDotnet.Interface;
using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal class GetDownloadLinkRequest : RequestBase
{
  public GetDownloadLinkRequest(INode node)
    : base("l")
  {
    Id = node.Id;
  }

  [JsonProperty("n")]
  public string Id { get; private set; }
}
