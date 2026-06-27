using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketCreateProxiedVehicleRace : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketCreateProxiedVehicleRace>
{
    public new const short OpCode = 11;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketCreateProxiedVehicleRace() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketCreateProxiedVehicleRace value)
    {
        value = new VehicleRacePacketCreateProxiedVehicleRace();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
