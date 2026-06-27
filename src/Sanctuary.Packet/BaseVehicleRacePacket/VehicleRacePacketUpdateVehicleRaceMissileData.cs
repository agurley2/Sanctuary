using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleRaceMissileData : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleRaceMissileData>
{
    public new const short OpCode = 26;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketUpdateVehicleRaceMissileData() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleRaceMissileData value)
    {
        value = new VehicleRacePacketUpdateVehicleRaceMissileData();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
