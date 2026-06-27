using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer>
{
    public new const short OpCode = 6;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer value)
    {
        value = new VehicleDemolitionDerbyPacketRegisterVehicleDemolitionDerbyPlayer();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
