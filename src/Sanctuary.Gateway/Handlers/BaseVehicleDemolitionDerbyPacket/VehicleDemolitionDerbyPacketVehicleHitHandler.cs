using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class VehicleDemolitionDerbyPacketVehicleHitHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(VehicleDemolitionDerbyPacketVehicleHitHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, ReadOnlySpan<byte> data)
    {
        if (!VehicleDemolitionDerbyPacketVehicleHit.TryDeserialize(data, out var packet))
        {
            _logger.LogError("Failed to deserialize {packet}.", nameof(VehicleDemolitionDerbyPacketVehicleHit));
            return false;
        }

        _logger.LogTrace("Received {name} packet. ( {packet} )", nameof(VehicleDemolitionDerbyPacketVehicleHit), packet);

        return true;
    }
}
