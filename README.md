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

The tests measure time it takes to read/write each block (RAM -> Disk, Disk -> RAM, RAM ->), conduct operations in sequential and random manner and show, let you choose read/write modes (e.g. turning on/off write buffering and file cache in memory) and show the average thrpughput (total traffic over total time) in MB/s of each test. The tests let you bencmark how same storage operations are handled by different OS across different devices and compare the results.

## Technology

Xamarin.Forms, .NET Framework and Xamarin.WPF on Windows, Mono and Xamarin.Mac on macOS, Mono and Xamarin.Android. Quite a few customer controls (Stack and Grid repeaters, clickable label) and reneresers (change mouse cursor when hovering over button and label on desktop)
