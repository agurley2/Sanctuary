using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData>
{
    public new const short OpCode = 5;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData value)
    {
        value = new VehicleDemolitionDerbyPacketUpdateVehicleDemolitionDerbyData();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
