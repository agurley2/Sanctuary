using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup>
{
    public new const short OpCode = 12;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup value)
    {
        value = new VehicleDemolitionDerbyPacketCreateProxiedVehicleDemolitionDerbyPickup();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
