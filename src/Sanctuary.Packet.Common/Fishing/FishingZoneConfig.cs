using Sanctuary.Core.IO;

namespace Sanctuary.Packet.Common;

public class FishingZoneConfig : ISerializableType
{
    public int Unknown6;

    public string? Unknown;

    public int Unknown2;
    public int Unknown3;
    public int Unknown4;
    public int Unknown5;

    // public List<FishingSchoolInstanceDefinition> FishingSchoolInstances = [];
    // public Dictionary<int, FishingSchoolPathDefinition> FishingSchoolPaths = [];

    public void Serialize(PacketWriter writer)
    {
        writer.Write(Unknown);

        writer.Write(Unknown2);
        writer.Write(Unknown3);
        writer.Write(Unknown4);
        writer.Write(Unknown5);
        writer.Write(Unknown6);
    }
}