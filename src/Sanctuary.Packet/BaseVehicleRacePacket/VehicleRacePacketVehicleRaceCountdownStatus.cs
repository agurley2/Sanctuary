using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketVehicleRaceCountdownStatus : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketVehicleRaceCountdownStatus>
{
    public new const short OpCode = 10;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketVehicleRaceCountdownStatus() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketVehicleRaceCountdownStatus value)
    {
        value = new VehicleRacePacketVehicleRaceCountdownStatus();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
