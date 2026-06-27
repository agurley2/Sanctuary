using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Sanctuary.Core.IO;
using Sanctuary.Packet;
using Sanctuary.Packet.Common.Attributes;

namespace Sanctuary.Gateway.Handlers;

[PacketHandler]
public static class BaseVehicleRacePacketHandler
{
    private static ILogger _logger = null!;

    public static void ConfigureServices(IServiceProvider serviceProvider)
    {
        var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
        _logger = loggerFactory.CreateLogger(nameof(BaseVehicleRacePacketHandler));
    }

    public static bool HandlePacket(GatewayConnection connection, PacketReader reader)
    {
        if (!reader.TryRead(out short subOpCode))
        {
            _logger.LogError("Failed to read sub-opcode from packet. ( Data: {data} )", Convert.ToHexString(reader.Span));
            return false;
        }

        var data = reader.Span;

        _logger.LogTrace("Received VehicleRace packet subOpCode={subOpCode}, dataLen={len}", subOpCode, data.Length);

        return subOpCode switch
        {
            VehicleRacePacketUpdateVehicleGameState.OpCode =>
                VehicleRacePacketUpdateVehicleGameStateHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleGamePlayerState.OpCode =>
                VehicleRacePacketUpdateVehicleGamePlayerStateHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdatePlayerCount.OpCode =>
                VehicleRacePacketUpdatePlayerCountHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateNpcCount.OpCode =>
                VehicleRacePacketUpdateNpcCountHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleRaceClientData.OpCode =>
                VehicleRacePacketUpdateVehicleRaceClientDataHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleRaceServerData.OpCode =>
                VehicleRacePacketUpdateVehicleRaceServerDataHandler.HandlePacket(connection, data),
            VehicleRacePacketGateHit.OpCode =>
                VehicleRacePacketGateHitHandler.HandlePacket(connection, data),
            VehicleRacePacketVehicleHit.OpCode =>
                VehicleRacePacketVehicleHitHandler.HandlePacket(connection, data),
            VehicleRacePacketRegisterVehicleRacePlayer.OpCode =>
                VehicleRacePacketRegisterVehicleRacePlayerHandler.HandlePacket(connection, data),
            VehicleRacePacketVehicleRaceCountdownStatus.OpCode =>
                VehicleRacePacketVehicleRaceCountdownStatusHandler.HandlePacket(connection, data),
            VehicleRacePacketCreateProxiedVehicleRace.OpCode =>
                VehicleRacePacketCreateProxiedVehicleRaceHandler.HandlePacket(connection, data),
            VehicleRacePacketDestroyProxiedVehicleRace.OpCode =>
                VehicleRacePacketDestroyProxiedVehicleRaceHandler.HandlePacket(connection, data),
            VehicleRacePacketKickProxiedVehicleRace.OpCode =>
                VehicleRacePacketKickProxiedVehicleRaceHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleRaceProgressData.OpCode =>
                VehicleRacePacketUpdateVehicleRaceProgressDataHandler.HandlePacket(connection, data),
            VehicleRacePacketCreateProxiedVehicleRacePickup.OpCode =>
                VehicleRacePacketCreateProxiedVehicleRacePickupHandler.HandlePacket(connection, data),
            VehicleRacePacketDestroyProxiedVehicleRacePickup.OpCode =>
                VehicleRacePacketDestroyProxiedVehicleRacePickupHandler.HandlePacket(connection, data),
            VehicleRacePacketPickupHitRequest.OpCode =>
                VehicleRacePacketPickupHitRequestHandler.HandlePacket(connection, data),
            VehicleRacePacketPickupHitResponse.OpCode =>
                VehicleRacePacketPickupHitResponseHandler.HandlePacket(connection, data),
            VehicleRacePacketUseItemRequest.OpCode =>
                VehicleRacePacketUseItemRequestHandler.HandlePacket(connection, data),
            VehicleRacePacketUseItemResponse.OpCode =>
                VehicleRacePacketUseItemResponseHandler.HandlePacket(connection, data),
            VehicleRacePacketItemExpired.OpCode =>
                VehicleRacePacketItemExpiredHandler.HandlePacket(connection, data),
            VehicleRacePacketBoostAwardRequest.OpCode =>
                VehicleRacePacketBoostAwardRequestHandler.HandlePacket(connection, data),
            VehicleRacePacketBoostAwardResponse.OpCode =>
                VehicleRacePacketBoostAwardResponseHandler.HandlePacket(connection, data),
            VehicleRacePacketCreateProxiedVehicleRaceMissile.OpCode =>
                VehicleRacePacketCreateProxiedVehicleRaceMissileHandler.HandlePacket(connection, data),
            VehicleRacePacketDestroyProxiedVehicleRaceMissile.OpCode =>
                VehicleRacePacketDestroyProxiedVehicleRaceMissileHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleRaceMissileData.OpCode =>
                VehicleRacePacketUpdateVehicleRaceMissileDataHandler.HandlePacket(connection, data),
            VehicleRacePacketCreateProxiedVehicleRaceExplosion.OpCode =>
                VehicleRacePacketCreateProxiedVehicleRaceExplosionHandler.HandlePacket(connection, data),
            VehicleRacePacketDestroyProxiedVehicleRaceExplosion.OpCode =>
                VehicleRacePacketDestroyProxiedVehicleRaceExplosionHandler.HandlePacket(connection, data),
            VehicleRacePacketCreateProxiedVehicleRaceMine.OpCode =>
                VehicleRacePacketCreateProxiedVehicleRaceMineHandler.HandlePacket(connection, data),
            VehicleRacePacketDestroyProxiedVehicleRaceMine.OpCode =>
                VehicleRacePacketDestroyProxiedVehicleRaceMineHandler.HandlePacket(connection, data),
            VehicleRacePacketUpdateVehicleRaceMineData.OpCode =>
                VehicleRacePacketUpdateVehicleRaceMineDataHandler.HandlePacket(connection, data),
            VehicleRacePacketResetNpcsRequest.OpCode =>
                VehicleRacePacketResetNpcsRequestHandler.HandlePacket(connection, data),
            VehicleRacePacketResetProxiedVehicleRace.OpCode =>
                VehicleRacePacketResetProxiedVehicleRaceHandler.HandlePacket(connection, data),
            VehicleRacePacketSetRaceConfig.OpCode =>
                VehicleRacePacketSetRaceConfigHandler.HandlePacket(connection, data),
            _ => false
        };
    }
}
