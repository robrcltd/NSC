using System.Diagnostics;

public static class NetworkManager
{
    /// <summary>
    /// Configures a Network Interface to a Static IP address.
    /// </summary>
    public static bool SetStaticIP(string interfaceName, string ipAddress, string subnetMask, string gateway = "")
    {
        // Example: netsh interface ipv4 set address name="Ethernet" static 192.168.1.50 255.255.255.0 192.168.1.1
        string arguments = $"interface ipv4 set address name=\"{interfaceName}\" static {ipAddress} {subnetMask}";
        
        if (!string.IsNullOrWhiteSpace(gateway))
        {
            arguments += $" {gateway}";
        }

        return ExecuteNetsh(arguments);
    }

    /// <summary>
    /// Configures a Network Interface to use DHCP.
    /// </summary>
    public static bool SetDHCP(string interfaceName)
    {
        // Example: netsh interface ipv4 set address name="Ethernet" source=dhcp
        string arguments = $"interface ipv4 set address name=\"{interfaceName}\" source=dhcp";
        return ExecuteNetsh(arguments);
    }

    private static bool ExecuteNetsh(string arguments)
    {
        try
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "netsh",
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
                // A successful netsh command typically exits with code 0
                return process.ExitCode == 0;
            }
        }
        catch (Exception)
        {
            return false;
        }
    }
}
