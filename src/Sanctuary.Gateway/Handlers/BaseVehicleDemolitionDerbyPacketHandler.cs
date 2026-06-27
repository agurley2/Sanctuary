using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Core.IO;
using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class BaseVehicleDemolitionDerbyPacketHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(BaseVehicleDemolitionDerbyPacketHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, PacketReader reader)
    {
        if (!reader.TryRead(out short subOpCode))
        {
            _logger.LogError("Failed to read sub-opcode from packet. ( Data: {data} )", Convert.ToHexString(reader.Span));
            return false;
        }

        var data = reader.Span;

        _logger.LogTrace("Received VehicleDemolitionDerby packet subOpCode={subOpCode}, dataLen={len}", subOpCode, data.Length);

        return subOpCode switch
        {
            VehicleDemolitionDerbyPacketUpdateVehicleGameState.OpCode =>
                VehicleDemolitionDerbyPacketUpdateVehicleGameStateHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketUpdateVehicleGamePlayerState.OpCode =>
                VehicleDemolitionDerbyPacketUpdateVehicleGamePlayerStateHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketUpdatePlayerCount.OpCode =>
                VehicleDemolitionDerbyPacketUpdatePlayerCountHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketUpdateNpcCount.OpCode =>
                VehicleDemolitionDerbyPacketUpdateNpcCountHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData.OpCode =>
                VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyDataHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer.OpCode =>
                VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayerHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus.OpCode =>
                VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatusHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerby.OpCode =>
                VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerbyHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby.OpCode =>
                VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerbyHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby.OpCode =>
                VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyStateData.OpCode =>
                VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyStateDataHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup.OpCode =>
                VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickupHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerbyPickup.OpCode =>
                VehicleDemolitionDerbyPacketDestroyProxiedVehicleDemolitionDerbyPickupHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketPickupHitRequest.OpCode =>
                VehicleDemolitionDerbyPacketPickupHitRequestHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketPickupHitResponse.OpCode =>
                VehicleDemolitionDerbyPacketPickupHitResponseHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketVehicleHit.OpCode =>
                VehicleDemolitionDerbyPacketVehicleHitHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketItemExpired.OpCode =>
                VehicleDemolitionDerbyPacketItemExpiredHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketResetProxiedVehicleDemolitionDerby.OpCode =>
                VehicleDemolitionDerbyPacketResetProxiedVehicleDemolitionDerbyHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketSetDerbyConfig.OpCode =>
                VehicleDemolitionDerbyPacketSetDerbyConfigHandler.HandlePacket(connection, data),
            VehicleDemolitionDerbyPacketAnnouncerMessage.OpCode =>
                VehicleDemolitionDerbyPacketAnnouncerMessageHandler.HandlePacket(connection, data),
            _ => false
        };
    }
}
