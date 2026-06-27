using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketBoostAwardRequest : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketBoostAwardRequest>
{
    public new const short OpCode = 22;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketBoostAwardRequest() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketBoostAwardRequest value)
    {
        value = new VehicleRacePacketBoostAwardRequest();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
