using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class VehicleRacePacketUpdateVehicleRaceMineDataHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(VehicleRacePacketUpdateVehicleRaceMineDataHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, ReadOnlySpan<byte> data)
    {
        if (!VehicleRacePacketUpdateVehicleRaceMineData.TryDeserialize(data, out var packet))
        {
            _logger.LogError("Failed to deserialize {packet}.", nameof(VehicleRacePacketUpdateVehicleRaceMineData));
            return false;
        }

        _logger.LogTrace("Received {name} packet. ( {packet} )", nameof(VehicleRacePacketUpdateVehicleRaceMineData), packet);

        return true;
    }
}
