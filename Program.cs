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
			List<AlpacaDevice> devs = await AlpacaDiscovery.GetAlpacaDevicesAsync();
			if (devs.Count == 0)
			{
				Console.WriteLine("Nothing found, start up the Omni Simulator.");
				return;
			}
			Console.WriteLine($"{devs.Count} Alpaca devices found. Using the first.");
			AlpacaDevice dev = devs[0];
			Console.WriteLine($"{ dev.ServerName} at {dev.IpAddress}:{dev.Port}");
			List<AscomDevice> rots = dev.AscomDevices(DeviceTypes.Rotator);
			if (rots.Count == 0)
			{
				Console.WriteLine($"No Rotators here at {dev.ServerName}.");
				return;
			}
			Console.WriteLine($"{rots.Count} Rotator(s) here, using #0");
			AscomDevice rot = rots[0];
			string rotName = $"{rot.Manufacturer} Alpaca Rotator";
			// Note that the ASCOMDevice class includes Alpaca Information such as IP
			// address and port so that all information about the ASCOM device is
			// available in one data structure.
			Console.WriteLine($"Creating ASCOM Dynamic Driver for {rotName} on {rot.IpAddress}:{rot.IpPort}");
			string uid = Guid.NewGuid().ToString();
			Console.WriteLine($"Assigning Alpaca unique ID of {uid}");
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
