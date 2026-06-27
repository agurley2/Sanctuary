using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby>
{
    public new const short OpCode = 10;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby value)
    {
        value = new VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerby();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
