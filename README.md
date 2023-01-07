# COM to Alpaca Dynamic Driver Sample

This little C# .NET 6 app shows how to create a "dynamic" COM to Alpaca driver outside the Windows
ASCOM Chooser. This was written for Windows ASCOM/COM apps that do not want to use
the Chooser for providing access to Alpaca devices. 

## NuGet Packages
This uses the [ASCOM Cross-Platform Library](https://github.com/ASCOMInitiative/ASCOMLibrary#readme). 
Please make sure you have the 
[ASCOM Platform 6.6 SP1](https://github.com/ASCOMInitiative/ASCOMPlatform/releases/tag/v6.6SP1Release)
or later installed if you're on Windows. 
The library is distributed via NuGet and consists of five packages (search for `ASCOM` on NuGet):

* ASCOM.Alpaca.Components - ASCOM Alpaca Clients and Client Discovery Library.
* ASCOM.Alpaca.Device - Device / driver side discovery library.
* ASCOM.Com.Components - A .Net Standard (.Net Core / .Net 5+) access library for ASCOM COM drivers.
* ASCOM.Tools - A set of CrossPlatform tools for logging, settings and conversions.
* ASCOM.Common.Components - The types, interfaces and enums for the ASCOM CrossPlatform library.

If you're developing in C#, this is the library to use! It has loads of useful classes that support
both ASCOM/COM and ASCOM/Alpaca. 

It is our hope that this little sample will help you incorporate Alpaca connectivity into your
Chooser-less application wihout forcing your users to open the chooser in some other application
on the way to connecting to an Alpaca device from your app.

As always, questions and help at the 
[ASCOM Driver and Application Development Support Forum](https://ascomtalk.groups.io/g/Developer).