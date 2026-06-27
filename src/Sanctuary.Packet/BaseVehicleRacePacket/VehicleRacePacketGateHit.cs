using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketGateHit : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketGateHit>
{
    public new const short OpCode = 7;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketGateHit() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketGateHit value)
    {
        value = new VehicleRacePacketGateHit();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
