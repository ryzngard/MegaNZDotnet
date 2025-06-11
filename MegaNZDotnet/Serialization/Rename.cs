using MegaNZDotnet.Interface;

using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal class RenameRequest : RequestBase
{
    public RenameRequest(INode node, string attributes)
      : base("a")
    {
        Id = node.Id;
        SerializedAttributes = attributes;
    }

    [JsonProperty("n")]
    public string Id { get; private set; }

    [JsonProperty("attr")]
    public string SerializedAttributes { get; set; }
}