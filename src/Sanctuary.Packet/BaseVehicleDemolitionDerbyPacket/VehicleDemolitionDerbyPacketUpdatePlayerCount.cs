using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketUpdatePlayerCount : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketUpdatePlayerCount>
{
    public new const short OpCode = 3;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketUpdatePlayerCount() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketUpdatePlayerCount value)
    {
        value = new VehicleDemolitionDerbyPacketUpdatePlayerCount();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
