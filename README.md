# Let's Tag

Let's Tag assists in tagging game music albums.  It connects to vgmdb.net to download album data and exports it in a format that can be imported into Mp3tag.

**I stopped maintaining Let's Tag a long time ago because the alternative solutions available (see below) are much better.**

![Screenshot](Screenshot.png)

## Download

### Let's Tag v0.2.2
https://github.com/tomvoros/lets-tag/releases/tag/v0.2.2

## How to Use

Here's a slideshow demonstrating how to use Let's Tag with Mp3tag:  
https://docs.google.com/presentation/d/1VVsxFKsUv7I_9lPwckUHx_1J1F59uvIitz7l8ls7q5U/embed

## Alternatively...

Other ways to get VGMdb tag data that may be more convenient than using Let's Tag:
* VGMdb's official CDDB/freedb support (by Zorbfish):  
  http://vgmdb.net/forums/showthread.php?t=2618
* VGMdb data source for Mp3tag (by dano):  
  https://forums.mp3tag.de/index.php?showtopic=10991
* Another VGMdb data source for Mp3tag (by PBXg33k):  
  https://gist.github.com/PBXg33k/7b80a86d53b922f0873a

## Links

VGMdb:  
http://vgmdb.net

Let's Tag discussion thread on VGMdb Forums:  
http://vgmdb.net/forums/showthread.php?t=1902

Mp3tag:  
http://www.mp3tag.de/en/

## Release History

### Version 0.2.2 (July 23, 2017)
* Published Let's Tag to GitHub
* Updated Let's Tag to support the current version of vgmdb.net
* Updated the link in the About window to point to GitHub

### Version 0.2.1 (May 23, 2009)
* Added drag and drop for album cover.  When the album cover is dropped on an Explorer window, it is saved as folder.jpg.
* Added additional image formats for saving album cover.

### Version 0.2 (May 11, 2009)
* Cover art is downloaded and displayed. It can be copied to the clipboard (for pasting into Mp3tag) or saved to a file.
* Added a command line app, letstagc.exe, for those who want to use Let's Tag in scripts or batch files. (Functionality is fairly limited at the moment.)
* Export presets can be saved. They are saved as XML files in Let's Tag's Presets folder.
* Editing the export preset XML files by hand allows you to make more advanced presets. For example, it is possible to put multiple album fields into a single MP3 tag field.
* Code was refactored quite a bit, though it still needs some work.

### Version 0.1.1 (April 19, 2009)
* Fixed search results parser to accomodate a minor change in the HTML.

### Version 0.1 (February 17, 2009)
* Initial release.
