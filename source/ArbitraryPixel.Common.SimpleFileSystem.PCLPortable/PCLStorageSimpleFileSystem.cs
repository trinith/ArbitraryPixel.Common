using PCLStorage;
using System.Threading.Tasks;

namespace ArbitraryPixel.Common.SimpleFileSystem.PCLPortable
{
    public class PCLStorageFileSystem : ISimpleFileSystem
    {
        public void DeleteFile(string fileName)
        {
            var t = Task.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    var file = await root.GetFileAsync(fileName);
                    await file.DeleteAsync();
                }
            );
            t.Wait();
        }

        public bool FileExists(string fileName)
        {
            var t = Task<bool>.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    var result = await root.CheckExistsAsync(fileName);

                    return (result == ExistenceCheckResult.FileExists);
                }
            );
            t.Wait();

            return t.Result;
        }

        public bool FolderExists(string folderName)
        {
            var t = Task<bool>.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    var result = await root.CheckExistsAsync(folderName);

                    return (result == ExistenceCheckResult.FolderExists);
                }
            );
            t.Wait();

            return t.Result;
        }

        public string ReadFileContents(string fileName)
        {
            var t = Task<string>.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    var file = await root.GetFileAsync(fileName);
                    return await file.ReadAllTextAsync();
                }
            );
            t.Wait();

            return t.Result;
        }

        public void WriteFileContents(string fileName, string contents)
        {
            var t = Task.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    var file = await root.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
                    await file.WriteAllTextAsync(contents);
                }
            );
            t.Wait();
        }

        public void CreateFolder(string folderName)
        {
            var t = Task.Run(
                async () =>
                {
                    var root = FileSystem.Current.LocalStorage;
                    await root.CreateFolderAsync(folderName, CreationCollisionOption.FailIfExists);
                }
            );
            t.Wait();
        }
    }
}
