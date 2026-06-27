using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketBoostAwardResponse : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketBoostAwardResponse>
{
    public new const short OpCode = 23;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketBoostAwardResponse() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketBoostAwardResponse value)
    {
        value = new VehicleRacePacketBoostAwardResponse();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
