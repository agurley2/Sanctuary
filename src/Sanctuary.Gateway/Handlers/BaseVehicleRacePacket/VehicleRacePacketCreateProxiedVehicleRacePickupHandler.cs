using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class VehicleRacePacketCreateProxiedVehicleRacePickupHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(VehicleRacePacketCreateProxiedVehicleRacePickupHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, ReadOnlySpan<byte> data)
    {
        if (!VehicleRacePacketCreateProxiedVehicleRacePickup.TryDeserialize(data, out var packet))
        {
            _logger.LogError("Failed to deserialize {packet}.", nameof(VehicleRacePacketCreateProxiedVehicleRacePickup));
            return false;
        }

        _logger.LogTrace("Received {name} packet. ( {packet} )", nameof(VehicleRacePacketCreateProxiedVehicleRacePickup), packet);

        return true;
    }
}
