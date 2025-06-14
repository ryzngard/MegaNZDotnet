﻿
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

using MegaNZDotnet.Interface;
using MegaNZDotnet.Tests.Context;

using Polly;

namespace MegaNZDotnet.Tests;

internal class TestWebClient : IWebClient
{
    private static IWebClient s_webClient = CreateWebClient();

    private readonly Policy _policy;
    private readonly Action<string> _logMessageAction;

    public TestWebClient(int maxRetry, Action<string> logMessageAction)
    {
        _policy = Policy
          .Handle<WebException>()
          .Or<SocketException>()
          .Or<TaskCanceledException>()
          .Or<AggregateException>()
          .WaitAndRetry(maxRetry, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), OnRetry);
        _logMessageAction = logMessageAction;
    }

    public enum CallType
    {
        PostRequestJson,
        PostRequestRaw,
        PostRequestRawAsStream,
        GetRequestRaw
    }

    public event Action<CallType, Uri> OnCalled;

    public int BufferSize
    {
        get => s_webClient.BufferSize;
        set => s_webClient.BufferSize = value;
    }

    public string PostRequestJson(Uri url, string jsonData)
    {
        return _policy.Execute(() =>
        {
            var result = s_webClient.PostRequestJson(url, jsonData);
            OnCalled?.Invoke(CallType.PostRequestJson, url);

            return result;
        });
    }

    public string PostRequestRaw(Uri url, Stream dataStream)
    {
        return _policy.Execute(() =>
        {
            // Create a copy of the stream because webClient can dispose it
            // It's useful in case of retries
            var dataStreamCopy = CloneStream(dataStream);

            var result = s_webClient.PostRequestRaw(url, dataStreamCopy);
            OnCalled?.Invoke(CallType.PostRequestRaw, url);

            return result;
        });
    }

    public Stream PostRequestRawAsStream(Uri url, Stream dataStream)
    {
        return _policy.Execute(() =>
        {
            // Create a copy of the stream because webClient can dispose it
            // It's useful in case of retries
            var dataStreamCopy = CloneStream(dataStream);

            var result = s_webClient.PostRequestRawAsStream(url, dataStreamCopy);
            OnCalled?.Invoke(CallType.PostRequestRawAsStream, url);

            return result;
        });
    }

    public Stream GetRequestRaw(Uri url)
    {
        return _policy.Execute(() =>
        {
            var result = s_webClient.GetRequestRaw(url);
            OnCalled?.Invoke(CallType.GetRequestRaw, url);

            return result;
        });
    }

    private static Stream CloneStream(Stream dataStream)
    {
        var buffer = new byte[dataStream.Length];
        var cloneStream = new MemoryStream(buffer);
        dataStream.CopyTo(cloneStream);

        dataStream.Position = 0;
        cloneStream.Position = 0;

        return cloneStream;
    }

    private void OnRetry(Exception ex, TimeSpan ts)
    {
        s_webClient = CreateWebClient();

        if (ex is AggregateException aEx)
        {
            _logMessageAction("AggregateException...");
            ex = aEx.InnerException;

            if (ex is TaskCanceledException tEx)
            {
                _logMessageAction("TaskCanceledException...");
                if (tEx.InnerException != null)
                {
                    ex = tEx.InnerException;
                }
            }
        }

        _logMessageAction($"Request failed: {ts.TotalSeconds}s, {ex}, {ex.Message}");
    }

    private static IWebClient CreateWebClient()
    {
        return new MegaNZDotnet.WebClient(TestContext.WebTimeout, null);
    }
}