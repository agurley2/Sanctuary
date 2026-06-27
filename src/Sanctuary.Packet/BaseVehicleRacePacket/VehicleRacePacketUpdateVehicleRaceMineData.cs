using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleRaceMineData : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleRaceMineData>
{
    public new const short OpCode = 31;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketUpdateVehicleRaceMineData() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleRaceMineData value)
    {
        value = new VehicleRacePacketUpdateVehicleRaceMineData();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
