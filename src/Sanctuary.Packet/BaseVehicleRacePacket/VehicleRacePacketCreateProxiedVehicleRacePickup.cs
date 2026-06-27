using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketCreateProxiedVehicleRacePickup : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketCreateProxiedVehicleRacePickup>
{
    public new const short OpCode = 15;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketCreateProxiedVehicleRacePickup() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketCreateProxiedVehicleRacePickup value)
    {
        value = new VehicleRacePacketCreateProxiedVehicleRacePickup();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
