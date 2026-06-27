using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateNpcCount : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateNpcCount>
{
    public new const short OpCode = 4;

    public int NpcCount;

    public VehicleRacePacketUpdateNpcCount() : base(OpCode)
    {
    }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateNpcCount value)
    {
        value = new VehicleRacePacketUpdateNpcCount();

        var reader = new PacketReader(data);

        if (!value.TryRead(ref reader))
            return false;

        if (!reader.TryRead(out value.NpcCount))
            return false;

        return reader.RemainingLength == 0;
    }
}
