using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketUpdateNpcCount : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketUpdateNpcCount>
{
    public new const short OpCode = 4;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketUpdateNpcCount() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketUpdateNpcCount value)
    {
        value = new VehicleDemolitionDerbyPacketUpdateNpcCount();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
