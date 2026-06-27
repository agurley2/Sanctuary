using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketPickupHitResponse : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketPickupHitResponse>
{
    public new const short OpCode = 18;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketPickupHitResponse() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketPickupHitResponse value)
    {
        value = new VehicleRacePacketPickupHitResponse();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
