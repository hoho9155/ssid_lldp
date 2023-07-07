using System.Management;
using SimpleWifi;



//SSID


Console.WriteLine("SSID List:");
try
{
    var wifi = new Wifi();
    var accessPoints = wifi.GetAccessPoints();
    foreach (AccessPoint ap in accessPoints)
    {
        Console.WriteLine($"SSID: {ap.Name}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

/*
try
{
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
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
*/

//LLDP
Console.WriteLine("LLDP List:");

try
{
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
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}



