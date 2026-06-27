using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketItemExpired : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketItemExpired>
{
    public new const short OpCode = 21;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketItemExpired() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketItemExpired value)
    {
        value = new VehicleRacePacketItemExpired();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
