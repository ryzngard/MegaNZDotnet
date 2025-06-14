﻿using Newtonsoft.Json;

namespace MegaNZDotnet.Serialization;

internal class UploadUrlRequest : RequestBase
{
    public UploadUrlRequest(long fileSize)
      : base("u")
    {
        Size = fileSize;
    }

    [JsonProperty("s")]
    public long Size { get; private set; }
}

internal class UploadUrlResponse
{
    [JsonProperty("p")]
    public string Url { get; private set; }
}