# Cross Platform Disk Test

![UI](https://raw.githubusercontent.com/maxim-saplin/CrossPlatformDiskTest/master/Img.png)

## Download & Try

- Windows (x86 and x64) and .NET Framework 4.7.2
  - https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/1.0.0/CPDriveTest.exe

- macOS 10.13+
  - https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/1.0.0/CPDiskTest.app.zip

- Android 4.4+ 
  - https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/1.0.0/com.Saplin.CPDT-Signed.apk

## How it works

The tests measure time it takes to read/write each block (RAM -> Disk, Disk -> RAM, RAM ->), let you choose read/write modes (e.g. turning on/off write buffering and file cache in memory), conduct sereies operations in sequential and random manner and show the average throughput (total traffic over total time) in MB/s for each test. The tests let you bencmark how same storage operations (FileStream.Write and FileStrem.Read) are handled by different OS across different devices and compare the results.

## Technology

Xamarin.Forms, .NET Framework and Xamarin.WPF on Windows, Mono and Xamarin.Mac on macOS, Mono and Xamarin.Android on Android. Quite a few customer controls (Stack and Grid repeaters, clickable label) and reneresers (change mouse cursor when hovering over button and label on desktop)
