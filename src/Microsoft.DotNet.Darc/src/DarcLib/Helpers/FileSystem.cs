// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Threading.Tasks;

#nullable enable
namespace Microsoft.DotNet.DarcLib.Helpers;

public class FileSystem : IFileSystem
{
    public char DirectorySeparatorChar => Path.DirectorySeparatorChar;

    public void CreateDirectory(string path) => Directory.CreateDirectory(path);

    public bool DirectoryExists(string path) => Directory.Exists(path);

    public bool FileExists(string path) => File.Exists(path);

    public void DeleteFile(string path) => File.Delete(path);

    public void DeleteDirectory(string path, bool recursive) => Directory.Delete(path, recursive);

    public string? GetDirectoryName(string? path) => Path.GetDirectoryName(path);

    public string[] GetFiles(string path) => Directory.GetFiles(path);

    public string? GetFileName(string? path) => Path.GetFileName(path);

    public string? GetFileNameWithoutExtension(string? path) => Path.GetFileNameWithoutExtension(path);

    public string? GetExtension(string? path) => Path.GetExtension(path);

    public string PathCombine(string path1, string path2) => Path.Combine(path1, path2);

    public string PathCombine(string path1, string path2, string path3) => Path.Combine(path1, path2, path3);

    public void WriteToFile(string path, string content)
    {
        var dirPath = Path.GetDirectoryName(path) ?? throw new DirectoryNotFoundException($"Invalid path {path}");
        Directory.CreateDirectory(dirPath);
        File.WriteAllText(path, content);
    }

    public void CopyFile(string sourceFileName, string destFileName, bool overwrite = false) => File.Copy(sourceFileName, destFileName, overwrite);

    public void MoveFile(string sourceFileName, string destFileName, bool overwrite = false) => File.Move(sourceFileName, destFileName, overwrite);

    public Stream GetFileStream(string path, FileMode mode, FileAccess access) => new FileStream(path, mode, access);

    public FileAttributes GetAttributes(string path) => File.GetAttributes(path);

    public IFileInfo GetFileInfo(string path) => new FileInfoWrapper(path);

    public Task<string> ReadAllTextAsync(string path) => File.ReadAllTextAsync(path);
}
