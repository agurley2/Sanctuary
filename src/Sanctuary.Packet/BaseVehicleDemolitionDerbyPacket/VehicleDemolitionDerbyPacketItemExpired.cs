using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketItemExpired : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketItemExpired>
{
    public new const short OpCode = 17;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketItemExpired() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketItemExpired value)
    {
        value = new VehicleDemolitionDerbyPacketItemExpired();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
