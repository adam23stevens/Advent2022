using System;
namespace Advent2022.DaySeven
{
	public static class Program
	{
		private static Dir currentDir = new Dir("/", null);
		private static List<Dir> dirMapping = new List<Dir>() { currentDir };

		public static string GetAnswer1()
        {
            ProcessDirectories();

            var answer = dirMapping.Where(x => x.TotalSize < 100000).Sum(x => x.TotalSize).ToString();
            return answer;
        }

		public static string GetAnswer2()
		{
			const long TotNeededForUpdate = 30000000;
			const long TotInSystem = 70000000;
			var totalSpaceUsed = dirMapping.First(x => x.Name == "/").TotalSize;
			var totalSpaceRemaining = TotInSystem - totalSpaceUsed;
			var totalSpaceNeeded = TotNeededForUpdate - totalSpaceRemaining;

            var answer = dirMapping.Where(x => x.TotalSize > totalSpaceNeeded)
								   .OrderBy(x => x.TotalSize)
								   .First()
								   .TotalSize
								   .ToString();

			return answer;
        }

        private static void ProcessDirectories()
        {
            var lines = FileReader.ReadFile();

            for (int x = 1; x < lines.Count();)
            {
                var line = lines[x];
                if (line.Contains("$ cd .."))
                {
                    Command_cd_back(x);
                }
                else if (line.Contains("$ cd "))
                {
                    Command_cd(line);
                }
                if (line.Contains("$ ls"))
                {
                    var listedItems = new List<string>();
                    x++;
                    while (x < lines.Count() && !lines[x].Contains("$"))
                    {
                        listedItems.Add(lines[x]);
                        x++;
                    }
                    Command_ls(listedItems);
                }
                else
                {
                    x++;
                }
            }
        }

        private static void Command_cd(string command)
		{
            var newDirName = command.Replace("$ cd ", "");

			currentDir = currentDir.Dirs.First(x => x.Name == newDirName);
		}

		private static void Command_cd_back(int step)
		{
			currentDir = dirMapping.First(d => d.Id == currentDir.ParentId);	
		}

		private static void Command_ls(List<string> items)
		{
			foreach(var item in items)
			{
				if (item.Contains("dir "))
				{
					var dirName = item.Replace("dir ", "");
					if (!dirMapping.Any(x => x.Name == dirName && x.ParentId == currentDir.Id))
					{
						var newDir = new Dir(dirName, currentDir.Id);
						
						dirMapping.First(x => x.Id == currentDir.Id).Dirs.Add(newDir);
						dirMapping.Add(newDir);
					}
				}
				else
				{
					var fileDetails = item.Split(' ');
					var fileSize = long.Parse(fileDetails[0]);
					
					var fileName = fileDetails[1];
					var fileExtension = "";
					if (fileName.Contains('.'))
					{
                        fileName = fileDetails[1].Split('.')[0];
                        fileExtension = fileDetails[1].Split('.')[1];
                    }

                    if (!dirMapping.First(d => d.Id == currentDir.Id).Files.Any(x => x.Name == fileName && x.FileExtension == fileExtension && x.Size == fileSize))
					{
						dirMapping.First(d => d.Id == currentDir.Id).Files.Add(
							new File(fileName, fileExtension, fileSize, currentDir.Id));
					}
				}
			}
		}
	}

	public class Dir
	{
		public Dir (string name, Guid? parentId)
		{
			Id = Guid.NewGuid();
			Name = name;
			ParentId = parentId;
			Dirs = new List<Dir>();
			Files = new List<File>();
		}
		public Guid Id { get; set; }
		public Guid? ParentId { get; set; }
		public string Name { get; set; }
		public List<Dir> Dirs { get; set; }
		public List<File> Files { get; set; }
		public long TotalSize => Dirs.Sum(x => x.TotalSize) + Files.Sum(x => x.Size);
	}
	public class File
	{
		public File(string name, string fileExtension, long size, Guid parentDirId)
		{
			Id = Guid.NewGuid();
			Name = name;
			FileExtension = fileExtension;
			Size = size;
			ParentDirId = parentDirId;
		}
		public Guid Id { get; set; }
		public Guid ParentDirId { get; set; }
		public string Name { get; set; }
		public string FileExtension { get; set; }
		public long Size { get; set; }
	}
}