using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketDestroyProxiedVehicleRaceMissile : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketDestroyProxiedVehicleRaceMissile>
{
    public new const short OpCode = 25;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketDestroyProxiedVehicleRaceMissile() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketDestroyProxiedVehicleRaceMissile value)
    {
        value = new VehicleRacePacketDestroyProxiedVehicleRaceMissile();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
