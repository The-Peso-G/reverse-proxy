// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using System.Collections.Generic;
using Xunit;

namespace Microsoft.ReverseProxy.Abstractions.Tests
{
    public class ProxyRouteTests
    {
        [Fact]
        public void Constructor_Works()
        {
            new ProxyRoute();
        }

        [Fact]
        public void DeepClone_Works()
        {
            // Arrange
            var sut = new ProxyRoute
            {
                RouteId = "route1",
                Match =
                {
                    Methods = new[] { "GET", "POST" },
                    Host = "example.com",
                    Path = "/",
                },
                Priority = 2,
                ClusterId = "cluster1",
                AuthorizationPolicy = "policy1",
                Metadata = new Dictionary<string, string>
                {
                    { "key", "value" },
                },
            };

            // Act
            var clone = sut.DeepClone();

            // Assert
            Assert.NotSame(sut, clone);
            Assert.Equal(sut.RouteId, clone.RouteId);
            Assert.NotSame(sut.Match, clone.Match);
            Assert.NotSame(sut.Match.Methods, clone.Match.Methods);
            Assert.Equal(sut.Match.Methods, clone.Match.Methods);
            Assert.Equal(sut.Match.Host, clone.Match.Host);
            Assert.Equal(sut.Match.Path, clone.Match.Path);
            Assert.Equal(sut.Priority, clone.Priority);
            Assert.Equal(sut.ClusterId, clone.ClusterId);
            Assert.Equal(sut.AuthorizationPolicy, clone.AuthorizationPolicy);
            Assert.NotNull(clone.Metadata);
            Assert.NotSame(sut.Metadata, clone.Metadata);
            Assert.Equal("value", clone.Metadata["key"]);
        }

        [Fact]
        public void DeepClone_Nulls_Works()
        {
            // Arrange
            var sut = new ProxyRoute();

            // Act
            var clone = sut.DeepClone();

            // Assert
            Assert.NotSame(sut, clone);
            Assert.Null(clone.RouteId);
            Assert.Null(clone.Match.Methods);
            Assert.Null(clone.Match.Host);
            Assert.Null(clone.Match.Path);
            Assert.Null(clone.Priority);
            Assert.Null(clone.ClusterId);
            Assert.Null(clone.AuthorizationPolicy);
            Assert.Null(clone.Metadata);
        }
    }
}
