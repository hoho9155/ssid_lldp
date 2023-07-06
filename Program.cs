using System.Management;


//SSID
Console.WriteLine("SSID List:");
String query = "SELECT * FROM MSNDis_80211_BSSIList";
ManagementObjectSearcher searcher = new ManagementObjectSearcher("root/WMI", query);
ManagementObjectCollection moc = searcher.Get();
ManagementObjectCollection.ManagementObjectEnumerator moe = moc.GetEnumerator();
moe.MoveNext();
ManagementBaseObject[] objarr = (ManagementBaseObject[])moe.Current.Properties["Ndis80211BSSIList"].Value;
foreach (ManagementBaseObject obj in objarr)
{
    uint u_ssid = (uint)obj["Ndis80211Ssid"];
    int ssid = (int)u_ssid;
    Console.WriteLine($"SSID: {ssid}");
}

//LLDP
Console.WriteLine("LLDP List:");
ManagementClass wmiClass = new ManagementClass("root\\StandardCimv2", "MSFT_NetAdapterLldp", null);
ManagementObjectCollection adapters = wmiClass.GetInstances();
foreach (ManagementObject adapter in adapters)
{
    string chassisId = adapter["ChassisID"].ToString();
    string portId = adapter["PortID"].ToString();

    Console.WriteLine($"Chassis ID: {chassisId}");
    Console.WriteLine($"Port ID: {portId}");
}
// Clean up the management objects
adapters.Dispose();
wmiClass.Dispose();