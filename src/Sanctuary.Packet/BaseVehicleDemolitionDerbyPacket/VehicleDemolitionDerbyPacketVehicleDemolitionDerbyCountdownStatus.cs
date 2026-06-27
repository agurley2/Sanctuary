using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus>
{
    public new const short OpCode = 7;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus value)
    {
        value = new VehicleDemolitionDerbyPacketVehicleDemolitionDerbyCountdownStatus();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
