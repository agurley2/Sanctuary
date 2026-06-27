using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketPickupHitRequest : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketPickupHitRequest>
{
    public new const short OpCode = 17;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketPickupHitRequest() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketPickupHitRequest value)
    {
        value = new VehicleRacePacketPickupHitRequest();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
