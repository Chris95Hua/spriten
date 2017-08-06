# sprite<sup>n</sup>
sprite<sup>n</sup> is a sprite editor and a generative tool for simple sprite generation. The key features include:
* Procedural sprite generation using masks
* Texture generation using texture synthesis


Since this project is supposed to be nothing more but a prototype and proof of concept that generative tool can be useful when integrated into a sprite editor, it lacks a lot of features found in some popular paint or sprite editor. However, I do plan to add more features in somewhere down the road (see [To-Do List](#to-do-list)). Also, see [Frequently Asked Questions](#frequently-asked-questions) for more information.

**Disclaimer:** While I did my best to squash all the bugs I could find, by no means that this software is production-ready (see [Known Issues](#known-issues)). Therefore I will not be held responsible in any way if you lose your progress while using this software.


## Software Requirement
Microsoft .NET Framework 4.5.2


## Frequently Asked Questions
#### Is there a Linux or macOS release?
Sadly, this is Windows only. However, porting it to Mono shouldn't be too hard, but then I don't have the time to do it myself. 


#### Where are the user guide and help documents?
There are none to begin with but the learning curve should be low if you have some experience with Adobe Photoshop, Krita or similar paint editor in the past. In case you are looking for tutorial or explanations of the mask used for procedural generation, check [here](http://web.archive.org/web/20080228054410/http://www.davebollinger.com/works/pixelspaceships/).

#### Can you add [feature]?
No.

#### Will you maintain and continue the development of this project in future?
Unlikely, unless I really have an awful lot of free time on my hands. However, feel free to fork this project and contribute if you wish to see this project in a more complete state.

#### Why WinForms instead of WPF?
While WPF is generally superior, it is not exactly as lightweight as I wanted after having experimented with a version build using WPF in early development stages. Indeed, sprite<sup>n</sup> will benefit a lot from the hardware acceleration offered by WPF, but GDI+ isn't *that* slow to begin with. Also, I doubt I can actually meet the tight deadline if I were to go with WPF since I don't have much experience working with WPF.

#### Oi, your code is inconsistent, full of poor design choices and bad programming practices.
In my defense, I only have 3 months to work on this along with other projects so I can't be bothered with good codes.


## To-Do List:
- [ ] Undo and redo stack
- [ ] Shortcuts
- [ ] Color replacer tool
- [ ] Shapes and line tool
- [ ] Color palette (with ability to load and save)
- [ ] Multithreading support
- [ ] Code cleanup and optimization

**Note:** The development, releases and timing of any features or functionality described are depend on my personal free time and interest. Thus, this list is subject to change and does not represent a commitment, obligation or promise to deliver any features at any time.


## Known Issues
* Bucket fill will leak if the fill region is enclosed with diagonally adjacent pixels.
* Tool's opacity affects the lightness of color instead of just the alpha channel.
* Layer selection doesn't get updated when merging, moving or removing the selected layers.



## Credits
* Original idea by [Dave Bollinger](http://web.archive.org/web/20080228054410/http://www.davebollinger.com/works/pixelspaceships/) and [zfedoran from Reddit](https://www.reddit.com/user/zfedoran)
* ColorPicker by [Warren Galyen](http://www.mechanikadesign.com/software/colorpicker-controls-for-windows-forms/)
* [ObjectListView](http://objectlistview.sourceforge.net/cs/index.html) by Phillip Piper
* [DockPanel Suite](http://dockpanelsuite.com/) by [Lex Li](https://github.com/lextm) and [Ryan Rastedt](https://github.com/roken)
* [mxgmn](https://github.com/mxgmn/SynTex)'s implementation of texture synthesis
* Icons by [Amit Jakhu](https://www.flaticon.com/authors/amit-jakhu), [Madebyoliver](https://smashicons.com/), [Freepik](http://www.freepik.com) from [Flaticon](www.flaticon.com)
