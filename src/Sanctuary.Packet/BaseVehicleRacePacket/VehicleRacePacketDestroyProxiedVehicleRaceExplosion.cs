using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketDestroyProxiedVehicleRaceExplosion : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketDestroyProxiedVehicleRaceExplosion>
{
    public new const short OpCode = 28;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketDestroyProxiedVehicleRaceExplosion() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketDestroyProxiedVehicleRaceExplosion value)
    {
        value = new VehicleRacePacketDestroyProxiedVehicleRaceExplosion();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
