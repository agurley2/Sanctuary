using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdatePlayerCount : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdatePlayerCount>
{
    public new const short OpCode = 3;

    public int PlayerCount;

    public VehicleRacePacketUpdatePlayerCount() : base(OpCode)
    {
    }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdatePlayerCount value)
    {
        value = new VehicleRacePacketUpdatePlayerCount();

        var reader = new PacketReader(data);

        if (!value.TryRead(ref reader))
            return false;

        if (!reader.TryRead(out value.PlayerCount))
            return false;

        return reader.RemainingLength == 0;
    }
}
