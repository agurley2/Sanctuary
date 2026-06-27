using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUseItemResponse : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUseItemResponse>
{
    public new const short OpCode = 20;

    public byte[] Data = Array.Empty<byte>();

    public VehicleRacePacketUseItemResponse() : base(OpCode) { }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUseItemResponse value)
    {
        value = new VehicleRacePacketUseItemResponse();
        var reader = new PacketReader(data);
        if (!value.TryRead(ref reader)) return false;
        if (reader.RemainingLength > 0)
            value.Data = reader.Read(reader.RemainingLength).ToArray();
        return true;
    }
}
