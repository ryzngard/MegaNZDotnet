
using MegaNZDotnet.Interface;
using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal class DeleteRequest : RequestBase
{
  public DeleteRequest(INode node)
    : base("d")
  {
    Node = node.Id;
  }

  [JsonProperty("n")]
  public string Node { get; private set; }
}
