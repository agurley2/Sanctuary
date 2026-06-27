using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class VehicleDemolitionDerbyPacketItemExpiredHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(VehicleDemolitionDerbyPacketItemExpiredHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, ReadOnlySpan<byte> data)
    {
        if (!VehicleDemolitionDerbyPacketItemExpired.TryDeserialize(data, out var packet))
        {
            _logger.LogError("Failed to deserialize {packet}.", nameof(VehicleDemolitionDerbyPacketItemExpired));
            return false;
        }

        _logger.LogTrace("Received {name} packet. ( {packet} )", nameof(VehicleDemolitionDerbyPacketItemExpired), packet);

        return true;
    }
}
