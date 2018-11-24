using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NugetBuilderAtCompilation
{
    [AttributeUsage(AttributeTargets.Assembly)]
    internal class ForceAssemblyReferenceAttribute : Attribute
    {
        public ForceAssemblyReferenceAttribute(Type[] types)
        {
            Action<Type> nothing = _ => { };
            foreach (Type type in types)
            {
                nothing(type);
            }
        }
    }
}
