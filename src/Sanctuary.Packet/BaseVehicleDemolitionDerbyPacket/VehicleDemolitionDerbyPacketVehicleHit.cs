using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketVehicleHit : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketVehicleHit>
{
    public new const short OpCode = 16;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketVehicleHit() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketVehicleHit value)
    {
        value = new VehicleDemolitionDerbyPacketVehicleHit();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
