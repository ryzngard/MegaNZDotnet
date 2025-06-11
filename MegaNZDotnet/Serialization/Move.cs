
using MegaNZDotnet.Interface;
using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal class MoveRequest : RequestBase
{
  public MoveRequest(INode node, INode destinationParentNode)
    : base("m")
  {
    Id = node.Id;
    DestinationParentId = destinationParentNode.Id;
  }

  [JsonProperty("n")]
  public string Id { get; private set; }

  [JsonProperty("t")]
  public string DestinationParentId { get; private set; }
}
