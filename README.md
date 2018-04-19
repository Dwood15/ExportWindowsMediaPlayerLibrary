# ExportWindowsMediaPlayerLibrary
Export your WMP/Windows Media Player library to csv in C#. 

Only really meant for Music, but if you follow the MSDN documents on available attributes for Windows Media Player, you'll be able to figure out what you want. 

I'd guess probably about 80% of the attributes for WMPLib are unused.

Ensure you add your WMP library to the csproj references!

There's no restriction on VS version I don't think. 

Warning: this script is horribly unoptimized. On a vanilla run, with a ~10k song library, it used >1.5 gigs of data! Force-flushing to disk seems to help somewhat, but I would recommend manually forcing garbage collection.
