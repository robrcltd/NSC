using System.IO;
using System.Text.Json;
using System.Collections.Generic;

public static class ProfileStorage
{
    private static readonly string FilePath = "network_profiles.json";

    public static void SaveProfiles(List<NetworkProfile> profiles)
    {
        string json = JsonSerializer.Serialize(profiles, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(FilePath, json);
    }

    public static List<NetworkProfile> LoadProfiles()
    {
        if (!File.Exists(FilePath)) return new List<NetworkProfile>();
        
        string json = File.ReadAllText(FilePath);
        return JsonSerializer.Deserialize<List<NetworkProfile>>(json) ?? new List<NetworkProfile>();
    }
}
