using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASCOM.Com;
using ASCOM.Common;
using ASCOM.Alpaca.Discovery;


namespace DynamicDriver
{
	class Program
	{
		static async Task Main(string[] args)
		{
			List<AlpacaDevice> svrs = await AlpacaDiscovery.GetAlpacaDevicesAsync();
			if (svrs.Count == 0)
			{
				Console.WriteLine("Nothing found, start up the Omni Server.");
				return;
			}
			Console.WriteLine($"{svrs.Count} Alpaca servers found. Using the first.");
			AlpacaDevice svr = svrs[0];
			Console.WriteLine($"{ svr.ServerName} at {svr.IpAddress}:{svr.Port}");
			List<AscomDevice> rots = svr.AscomDevices(DeviceTypes.Rotator);
			if (rots.Count == 0)
			{
				Console.WriteLine($"No Rotators served by {svr.ServerName}.");
				return;
			}
			Console.WriteLine($"{rots.Count} Rotators served here, using #0");
			AscomDevice rot = rots[0];
			string rotName = $"{rot.Manufacturer} Alpaca Rotator";
			// Note that the ASCOM Device also has useful server properties
			Console.WriteLine($"Creating ASCOM Dynamic Driver for {rotName} on {rot.IpAddress}:{rot.IpPort}");
			string uid = Guid.NewGuid().ToString();
			string result = PlatformUtilities.CreateDynamicDriver(
				DeviceTypes.Rotator,
				0,
				rotName,
				rot.IpAddress,
				rot.IpPort,
				uid);
			Console.WriteLine("Done. The COM ProgID is \"" + result + "\"");

		}
	}
}
