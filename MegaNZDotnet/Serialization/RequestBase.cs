
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal abstract class RequestBase
{
  protected RequestBase(string action)
  {
    Action = action;
    QueryArguments = new Dictionary<string, string>();
  }

  [JsonProperty("a")]
  public string Action { get; private set; }

  [JsonIgnore]
  public Dictionary<string, string> QueryArguments { get; }
}
