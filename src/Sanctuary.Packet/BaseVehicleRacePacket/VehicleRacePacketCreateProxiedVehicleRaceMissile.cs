using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketCreateProxiedVehicleRaceMissile : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketCreateProxiedVehicleRaceMissile>
{
    public new const short OpCode = 24;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketCreateProxiedVehicleRaceMissile() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketCreateProxiedVehicleRaceMissile value)
    {
        value = new VehicleRacePacketCreateProxiedVehicleRaceMissile();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
