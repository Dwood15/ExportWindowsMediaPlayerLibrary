using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WMPLib;
using MySql.Data;
namespace MusicDataDumper {
	class Program {
		static void Main(string[] args) {
			var sw = File.CreateText("songdata.csv");

			WindowsMediaPlayer wmpc = new WindowsMediaPlayer();
			var mediaCollection = wmpc.mediaCollection.getByAttribute("MediaType", "audio");
			var mediaCount = mediaCollection.count;

			Console.WriteLine("Queried the media library! \n Num items in collection: {0} \t attrCount: {1}", mediaCollection.count, mediaCollection.attributeCount);

			sw.WriteLine("Title,Album,Artist,TrackNumber,UserPlayCount,UserLastPlayedTime,Description,SourceURL,FileType,FileSize,Duration,CanonicalFileType");

			int sinceFlush = 0;

			for (int i = 0; i < mediaCount; i++) {
				var mediaItem = mediaCollection.Item[i];
				//var durationString = mediaItem.durationString;
				//var name = mediaItem.name;
				//var attributeCount = mediaItem.attributeCount;

				string attr = "\"" + mediaItem.getItemInfo("Title") + "\",";
				attr += "\"" + mediaItem.getItemInfo("Album") + "\",";
				attr += "\"" + mediaItem.getItemInfo("Artist") + "\",";
				attr += "\"" + mediaItem.getItemInfo("TrackNumber") + "\",";
				attr += "\"" + mediaItem.getItemInfo("UserPlayCount") + "\",";
				attr += "\"" + mediaItem.getItemInfo("UserLastPlayedTime") + "\",";
				attr += "\"" + mediaItem.getItemInfo("Description") + "\",";
				attr += "\"" + mediaItem.getItemInfo("SourceURL") + "\",";
				attr += "\"" + mediaItem.getItemInfo("FileType") + "\",";
				attr += "\"" + mediaItem.getItemInfo("FileSize") + "\",";
				attr += "\"" + mediaItem.getItemInfo("Duration") + "\",";
				attr += "\"" + mediaItem.getItemInfo("CanonicalFileType") + "\"\n";

				if (!String.IsNullOrWhiteSpace(attr)) {
					sw.Write(attr);
				}

				if(++sinceFlush > 50) {
					sw.Flush();
					sinceFlush = 0;
				}
			}

			sw.Close();
			Console.ReadKey();
		}
	}
}
