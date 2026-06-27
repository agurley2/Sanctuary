using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketResetNpcsRequest : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketResetNpcsRequest>
{
    public new const short OpCode = 32;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketResetNpcsRequest() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketResetNpcsRequest value)
    {
        value = new VehicleRacePacketResetNpcsRequest();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
