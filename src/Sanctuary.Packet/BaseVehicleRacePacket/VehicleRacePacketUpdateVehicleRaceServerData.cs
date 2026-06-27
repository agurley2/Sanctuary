using System;
using System.Numerics;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleRaceServerData : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleRaceServerData>
{
    public new const short OpCode = 6;

    public Vector4 Unknown1;
    public Vector4 Unknown2;
    public float Steering;
    public float Throttle;
    public float Speed;
    public int Unknown3;

    public VehicleRacePacketUpdateVehicleRaceServerData() : base(OpCode)
    {
    }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleRaceServerData value)
    {
        value = new VehicleRacePacketUpdateVehicleRaceServerData();

        var reader = new PacketReader(data);

        if (!value.TryRead(ref reader))
            return false;

        if (!reader.TryRead(out value.Unknown1))
            return false;
        if (!reader.TryRead(out value.Unknown2))
            return false;
        if (!reader.TryRead(out value.Steering))
            return false;
        if (!reader.TryRead(out value.Throttle))
            return false;
        if (!reader.TryRead(out value.Speed))
            return false;
        if (!reader.TryRead(out value.Unknown3))
            return false;

        return reader.RemainingLength == 0;
    }
}
