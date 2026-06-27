using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleRaceProgressData : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleRaceProgressData>
{
    public new const short OpCode = 14;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketUpdateVehicleRaceProgressData() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleRaceProgressData value)
    {
        value = new VehicleRacePacketUpdateVehicleRaceProgressData();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
