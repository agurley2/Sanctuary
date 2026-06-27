using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketCreateProxiedVehicleRaceExplosion : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketCreateProxiedVehicleRaceExplosion>
{
    public new const short OpCode = 27;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketCreateProxiedVehicleRaceExplosion() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketCreateProxiedVehicleRaceExplosion value)
    {
        value = new VehicleRacePacketCreateProxiedVehicleRaceExplosion();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
