using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleDemolitionDerbyPacketUpdateVehicleGameState : BaseVehicleDemolitionDerbyPacket, IDeserializable<VehicleDemolitionDerbyPacketUpdateVehicleGameState>
{
    public new const short OpCode = 1;

    public byte[] Data = Array.Empty<byte>();

    public VehicleDemolitionDerbyPacketUpdateVehicleGameState() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleDemolitionDerbyPacketUpdateVehicleGameState value)
    {
        value = new VehicleDemolitionDerbyPacketUpdateVehicleGameState();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
