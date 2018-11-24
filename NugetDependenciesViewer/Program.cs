using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;

namespace NugetDependenciesViewer
{
    // https://stackoverflow.com/questions/6653715/view-nuget-package-dependency-hierarchy

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the local repo folder (ie  C:\\...\\packages\\) : ");
            var repoFolder = Console.ReadLine();

            var repo = new LocalPackageRepository(repoFolder);
            IQueryable<IPackage> packages = repo.GetPackages();
            OutputGraph(repo, packages, 0);

            Console.Write("Press enter to exit :");
            Console.ReadLine();
        }

        static void OutputGraph(LocalPackageRepository repository, IEnumerable<IPackage> packages, int depth)
        {
            foreach (IPackage package in packages)
            {
                Console.WriteLine("{0}{1} v{2}", new string(' ', depth), package.Id, package.Version);

                IList<IPackage> dependentPackages = new List<IPackage>();
                foreach (var dependencySet in package.DependencySets)
                {
                    foreach (var dependency in dependencySet.Dependencies)
                    {
                        var dependentPackage = repository.FindPackage(dependency.Id, dependency.VersionSpec, true, true);
                        if (dependentPackage != null)
                        {
                            dependentPackages.Add(dependentPackage);
                        }
                    }
                }

                OutputGraph(repository, dependentPackages, depth += 3);
            }
        }
    }
}
