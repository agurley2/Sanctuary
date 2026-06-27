using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketPickupHitResponse : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketPickupHitResponse>
{
    public new const short OpCode = 15;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketPickupHitResponse() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketPickupHitResponse value)
    {
        value = new VehicleDemolitionDerbyPacketPickupHitResponse();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
