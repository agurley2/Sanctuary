using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketCreateProxiedVehicleRaceMine : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketCreateProxiedVehicleRaceMine>
{
    public new const short OpCode = 29;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketCreateProxiedVehicleRaceMine() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketCreateProxiedVehicleRaceMine value)
    {
        value = new VehicleRacePacketCreateProxiedVehicleRaceMine();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
