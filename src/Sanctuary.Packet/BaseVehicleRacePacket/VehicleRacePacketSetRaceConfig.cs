using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketSetRaceConfig : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketSetRaceConfig>
{
    public new const short OpCode = 34;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketSetRaceConfig() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketSetRaceConfig value)
    {
        value = new VehicleRacePacketSetRaceConfig();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
