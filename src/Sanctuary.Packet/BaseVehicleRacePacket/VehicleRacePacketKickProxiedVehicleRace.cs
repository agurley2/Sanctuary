using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketKickProxiedVehicleRace : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketKickProxiedVehicleRace>
{
    public new const short OpCode = 13;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketKickProxiedVehicleRace() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketKickProxiedVehicleRace value)
    {
        value = new VehicleRacePacketKickProxiedVehicleRace();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
