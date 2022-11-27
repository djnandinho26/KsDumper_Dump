Minidump files contain a wealth of information allowing you to diagnose application crashes, thread deadlocks, performance problems, memory leaks etc.

Unfortunately there are not a lot of tools that provide access to the information stored in the dump files and those that do exist can be challenging to use at the best of times.

This application is the first step in creating a tool that provides a rich and powerful environment for visualizing and analyzing minidumps of processes running the CLR. The first step is getting access to the different data streams inside the file. The next step is interpreting that data and presenting it in a way that allows easy visualization and interaction in order to make problem solving intuitive and easy.

Follow [https://gregsplaceontheweb.wordpress.com](https://gregsplaceontheweb.wordpress.com) for details on PInvoke, using the DbgHelp library and more.

![Viewing the ModuleListStream](https://github.com/GregTheDev/MinidumpExplorer/blob/master/Images/Home_mde_main_window.png)

## Features
* Capture a customizable minidump of any running process
* View stream data contained within a minidump

## Stream availability
| Stream | Progress |
| ----- | ----- |
| CommentStreamA | Not planned * |
| CommentStreamW | Released (v0.8) |
| ExceptionStream | Released (v0.3) |
| FunctionTableStream | Not planned * |
| HandleDataStream | Released (v0.2) |
| HandleOperationListStream | Not planned * |
| [Memory64ListStream](http://gregsplaceontheweb.wordpress.com/2014/05/30/minidump-explorer-v0-2-reading-minidump-memoryliststream-and-memory64liststream) | Released (v0.2) |
| MemoryInfoListStream | Released (v0.3) |
| [MemoryListStream](http://gregsplaceontheweb.wordpress.com/2014/05/30/minidump-explorer-v0-2-reading-minidump-memoryliststream-and-memory64liststream) | Released (v0.2) |
| MiscInfoStream | Released (v0.4) |
| [ModuleListStream](http://gregsplaceontheweb.wordpress.com/2014/04/08/reading-minidump-files-part-3-of-4-reading-stream-data-returned-from-minidumpreaddumpstream/) | Released (v0.1) |
| SystemInfoStream | Released (v0.3) |
| SystemMemoryInfoView | Released (v0.6) |
| ThreadExListStream | Pending |
| ThreadInfoListStream | Released (v0.3) |
| ThreadListStream | Released (v0.2) |
| ThreadNamesList | Released (v0.8) |
| UnloadedModuleListStream | Released (v0.4) |

*The following streams will not be added for now due to lack of available test data: CommentStreamA, FunctionTableStream and HandleOperationListStream. If any body has crash dumps containing any of these streams please tweet "greg_nagel".

# KsDumper
![Demo](https://i.imgur.com/6XyMDxa.gif)

I always had an interest in reverse engineering. A few days ago I wanted to look at some game internals for fun, but it was packed & protected by EAC (EasyAntiCheat).
This means its handle were stripped and I was unable to dump the process from Ring3. I decided to try to make a custom driver that would allow me to copy the process memory without using OpenProcess.
I knew nothing about Windows kernel, PE file structure, so I spent a lot of time reading articles and forums to make this project.

## Features
- Dump any process main module using a kernel driver (both x86 and x64)
- Rebuild PE32/PE64 header and sections
- Works on protected system processes & processes with stripped handles (anti-cheats)

**Note**: Import table isn't rebuilt.

## Usage
Before using KsDumperClient, the KsDumper driver needs to be loaded.

It is unsigned so you need to load it however you want. I'm using drvmap for Win10.
Everything is provided in this release if you want to use it aswell.

- Run `Driver/LoadCapcom.bat` as Admin. Don't press any key or close the window yet !
- Run `Driver/LoadUnsignedDriver.bat` as Admin.
- Press enter in the `LoadCapcom` cmd to unload the driver.
- Run `KsDumperClient.exe`.
- Profit !

**Note**: The driver stays loaded until you reboot, so if you close KsDumperClient.exe, you can just reopen it !  
**Note2**: Even though it can dump both x86 & x64 processes, this has to run on x64 Windows.

## Disclaimer
This project was a way for me to learn about Windows kernel, PE file structure and kernel-user space interactions. It has been made available for informational and educational purposes only.

Considering the nature of this project, it is highly recommended to run it in a `Virtual Environment`. I am not responsible for any crash or damage that could happen to your system.

**Important**: This tool makes no attempt at hiding itself. If you target protected games, the anti-cheat might flag this as a cheat and ban you after a while. Use a `Virtual Environment` !

## References
- https://github.com/not-wlan/drvmap
- https://github.com/Zer0Mem0ry/KernelBhop
- https://github.com/NtQuery/Scylla/
- http://terminus.rewolf.pl/terminus/
- https://www.unknowncheats.me/

## Compile Yourself
- Requires Visual Studio 2017
- Requires Windows Driver Kit (WDK)
- Requires .NET 4.6.1
