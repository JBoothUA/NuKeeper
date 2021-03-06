using System.Threading.Tasks;
using NuKeeper.Inspection.Files;
using NuKeeper.Inspection.Sources;

namespace NuKeeper.Update.Process
{
    public class SolutionsRestore
    {
        private readonly IFileRestoreCommand _fileRestoreCommand;

        public SolutionsRestore(IFileRestoreCommand fileRestoreCommand)
        {
            _fileRestoreCommand = fileRestoreCommand;
        }

        public async Task Restore(IFolder workingFolder, NuGetSources sources)
        {
            var solutionFiles = workingFolder.Find("*.sln");

            foreach (var sln in solutionFiles)
            {
                await _fileRestoreCommand.Invoke(sln, sources);
            }
        }
    }
}

