public class NetworkProfile
{
    public string ProfileName { get; set; } // e.g., "Line 1 PLC Network"
    public bool IsDHCP { get; set; }
    public string IPAddress { get; set; }
    public string SubnetMask { get; set; }
    public string Gateway { get; set; }

    public override string ToString() => ProfileName; // For easy UI list binding
}
