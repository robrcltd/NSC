using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

public List<string> GetNetworkAdapters()
{
    List<string> adapterNames = new List<string>();
    
    foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
    {
        // Filter for physical adapters typically used in Automation (Ethernet/Wi-Fi)
        if (nic.NetworkInterfaceType == NetworkInterfaceType.Ethernet) 
//            || nic.NetworkInterfaceType == NetworkInterfaceType.Wireless80211)
        {
            adapterNames.Add(nic.Name); // e.g., "Ethernet 1" or "Local Area Connection"
        }
    }
    return adapterNames;
}
