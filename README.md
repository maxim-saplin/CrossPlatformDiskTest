# Cross Platform Disk Test (CPDT)

Measuring storage performance (SSD, HDD, USB Flash etc.) and RAM speed across Windows, macOS and Android devices. Random and sequential throughput (read/write operations) is calculted in MB/s and can be compared in consistent and reliable manner between mobile and desktop platfotms and devices.

![UI](https://raw.githubusercontent.com/maxim-saplin/CrossPlatformDiskTest/master/Img%203.png)

## Download & Try

- Windows (x86 and x64) and .NET Framework 4.7.2
  - https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/2.0.0/CPDT.exe

- macOS 10.13+
  - https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/2.0.0/CPDT.app.zip

- Android 4.4+ 
  - Play Market: https://play.google.com/store/apps/details?id=com.Saplin.CPDT
  - APK: https://github.com/maxim-saplin/CrossPlatformDiskTest/releases/download/2.0.1/com.Saplin.CPDT.apk

## Benchmark chart

https://maxim-saplin.github.io/cpdt_results/

![Results](https://raw.githubusercontent.com/maxim-saplin/CrossPlatformDiskTest/master/Results.jpg)

## How it works

The tests measure time it takes to read/write each block (RAM -> Disk, Disk -> RAM, RAM ->), let you choose read/write modes (e.g. turning on/off write buffering and file cache in memory), conduct sereies operations in sequential and random manner and show the average throughput (total traffic over total time) in MB/s for each test. The tests let you bencmark how same storage operations (FileStream.Write and FileStrem.Read) are handled by different OS across different devices and compare the results.

![Concept](https://raw.githubusercontent.com/maxim-saplin/CrossPlatformDiskTest/master/EnBlack.png)

## Technology

Xamarin.Forms, .NET Framework and Xamarin.WPF on Windows, Mono and Xamarin.Mac on macOS, Mono and Xamarin.Android on Android. Quite a few custom controls (Stack and Grid repeaters, clickable label) and renderers (changing mouse cursor when hovering over button and label on desktop)
