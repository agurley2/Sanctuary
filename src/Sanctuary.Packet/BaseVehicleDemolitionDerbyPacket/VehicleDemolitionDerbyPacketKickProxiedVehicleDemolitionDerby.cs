using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby>
{
    public new const short OpCode = 9;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby value)
    {
        value = new VehicleDemolitionDerbyPacketKickProxiedVehicleDemolitionDerby();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
