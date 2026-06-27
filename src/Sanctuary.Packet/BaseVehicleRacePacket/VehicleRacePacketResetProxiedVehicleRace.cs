using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketResetProxiedVehicleRace : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketResetProxiedVehicleRace>
{
    public new const short OpCode = 33;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketResetProxiedVehicleRace() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketResetProxiedVehicleRace value)
    {
        value = new VehicleRacePacketResetProxiedVehicleRace();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
