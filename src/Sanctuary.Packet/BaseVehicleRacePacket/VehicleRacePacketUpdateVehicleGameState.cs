using System;

using Sanctuary.Core.IO;

namespace Sanctuary.Packet;

public class VehicleRacePacketUpdateVehicleGameState : BaseVehicleRacePacket, IDeserializable<VehicleRacePacketUpdateVehicleGameState>
{
    public new const short OpCode = 1;

    public float Unknown1;
    public float Unknown2;
    public float Unknown3;
    public float Unknown4;

    public VehicleRacePacketUpdateVehicleGameState() : base(OpCode)
    {
    }

    public static bool TryDeserialize(ReadOnlySpan<byte> data, out VehicleRacePacketUpdateVehicleGameState value)
    {
        value = new VehicleRacePacketUpdateVehicleGameState();

        var reader = new PacketReader(data);

        if (!value.TryRead(ref reader))
            return false;

        if (!reader.TryRead(out value.Unknown1))
            return false;
        if (!reader.TryRead(out value.Unknown2))
            return false;
        if (!reader.TryRead(out value.Unknown3))
            return false;
        if (!reader.TryRead(out value.Unknown4))
            return false;

        return reader.RemainingLength == 0;
    }
}
