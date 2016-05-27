using System;
using System.Collections.Generic;

namespace UpdateDB
{
    [Flags]
    public enum LoaderCategories
    {
        Any = 0,
        VersionControlled = 1,
        NotVersionControlled = 2,
        None = 4
    }

    public enum OutputDirectory
    {
        AppData,
        SourceCode,
        Current
    }

    public interface IArguments
    {
        LoaderCategories ActivatedLoader { get; }

        OutputDirectory OutputDirectory { get; }

        bool CreateBackup { get; }

        IEnumerable<string> LoaderFlags { get; }
    }
}