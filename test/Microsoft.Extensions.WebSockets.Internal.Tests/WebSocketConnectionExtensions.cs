// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.Extensions.WebSockets.Internal.Tests
{
    public static class WebSocketConnectionExtensions
    {
        public static async Task<WebSocketConnectionSummary> ExecuteAndCaptureFramesAsync(this IWebSocketConnection connection)
        {
            var frames = new List<WebSocketFrame>();
            var closeResult = await connection.ExecuteAsync(frame => frames.Add(frame.Copy()));
            return new WebSocketConnectionSummary(frames, closeResult);
        }
    }
}
