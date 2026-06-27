using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketVehicleHit : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketVehicleHit>
{
    public new const short OpCode = 8;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketVehicleHit() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketVehicleHit value)
    {
        value = new VehicleRacePacketVehicleHit();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
