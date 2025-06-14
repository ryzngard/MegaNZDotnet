﻿using System;

using Xunit;

namespace MegaNZDotnet.Tests.Context;

[CollectionDefinition(nameof(AnonymousAsyncTestContext))]
public class AnonymousLoginAsyncTestsCollection : ICollectionFixture<AnonymousAsyncTestContext> { }

public class AnonymousAsyncTestContext : AnonymousTestContext, IDisposable
{
    public void Dispose()
    {
        ((MegaApiClientAsyncWrapper)Client).Dispose();
    }

    protected override IMegaApiClient CreateClient()
    {
        return new MegaApiClientAsyncWrapper(base.CreateClient());
    }
}