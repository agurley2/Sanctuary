using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleGamePlayerState : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleGamePlayerState>
{
    public new const short OpCode = 2;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketUpdateVehicleGamePlayerState() : base(OpCode)
    {
    }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleGamePlayerState value)
    {
        value = new VehicleRacePacketUpdateVehicleGamePlayerState();

        var reader = new PacketReader(data);

        if (!value.TryRead(ref reader))
            return false;

        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();

        return true;
    }
}
