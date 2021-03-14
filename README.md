# A (almost) fully documented Emulator, originally written by Xyene github.com/Xyene
## The main resource used was the NES Dev Wiki --> http://wiki.nesdev.com/w/index.php/Nesdev_Wiki
 A C# emulator for Nintendo Entertainment System (NES) hardware.

![](http://i.imgur.com/aef0cM9.png) <!-- Donkey Kong -->
![](http://i.imgur.com/OjrvRmz.png) <!-- Super Mario Bros -->
![](http://i.imgur.com/OKPWHhP.png) <!-- Zelda -->
![](http://i.imgur.com/cga8ku8.png) <!-- Adventures of Lolo -->
![](http://i.imgur.com/Xyfp0AZ.png) <!-- Castlevania 2 -->
![](http://i.imgur.com/9lBMzz8.png) <!-- Contra -->



Emulator.NES will render video with OpenGL or Direct3D, depending on your platform. A slower software-only renderer
is also included for systems that support neither.

## Controls
Controls are currently hardcoded.

* A/S &mdash; A/B
* Arrow Keys &mdash; Up/Down/Left/Right
* Enter &mdash; Start
* Right Shift &mdash; Select

## Compatibility

The following mappers are implemented:

* 0 - [NROM](http://bootgod.dyndns.org:7777/search.php?ines=0)
* 1 - [MMC1](http://bootgod.dyndns.org:7777/search.php?ines=1)
* 2 - [UxROM](http://bootgod.dyndns.org:7777/search.php?ines=2)
* 3 - [CNROM](http://bootgod.dyndns.org:7777/search.php?ines=3)
* 4 - [MMC3](http://bootgod.dyndns.org:7777/search.php?ines=4)
* 7 - [AxROM](http://bootgod.dyndns.org:7777/search.php?ines=7)
* 9 - [MMC2](http://bootgod.dyndns.org:7777/search.php?ines=9) (*Mike Tyson's Punch-Out!!*)
* 10 - [MMC4](http://bootgod.dyndns.org:7777/search.php?ines=10)
* 11 - [Color Dreams](http://bootgod.dyndns.org:7777/search.php?ines=11)
* 66 - [GxROM](http://bootgod.dyndns.org:7777/search.php?ines=66)
* 71 - [Camerica](http://bootgod.dyndns.org:7777/search.php?ines=71)
* 79 - [NINA-003-006](http://bootgod.dyndns.org:7777/search.php?ines=79)
* 94 - [*Senjou no Ookami*](http://bootgod.dyndns.org:7777/search.php?ines=94)
* 140 - [Jaleco](http://bootgod.dyndns.org:7777/search.php?ines=140)
* 155 - [MMC1A](http://bootgod.dyndns.org:7777/search.php?ines=155)
* 180 - [*Crazy Climber*](http://bootgod.dyndns.org:7777/search.php?ines=180)
* 206 - [DxROM](http://bootgod.dyndns.org:7777/search.php?ines=206)


The APU is currently not implemented, which means no games output audio.

## Compilation
Emulator.NES uses C# 7 language features, so requires a compiler that supports them.

### Windows
Visual Studio 2017 is sufficient to compile.

### Linux
`msbuild` from Mono should be used to build, but the version included in most distro repositories is not
new enough to have C# 7 support (or may not have `msbuild`). Instead, [install a Mono version directly from the Mono site](http://www.mono-project.com/download/#download-lin).

Then, to compile:
```
$ nuget update -self
$ nuget restore
$ msbuild /property:Configuration=Release dotNES.sln
```

