using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketDestroyProxiedVehicleRaceMine : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketDestroyProxiedVehicleRaceMine>
{
    public new const short OpCode = 30;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketDestroyProxiedVehicleRaceMine() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketDestroyProxiedVehicleRaceMine value)
    {
        value = new VehicleRacePacketDestroyProxiedVehicleRaceMine();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
