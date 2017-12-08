using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppVersionControl.Facade
{
    public static class ExtensionFunctions
    {
        public static long GetVersionNumber(this Version version)
        {
            long major = version.Major;
            long minor = version.Minor;
            long build = version.Build;
            long revision = version.Revision;
            return (major << 48) + (minor << 32) + (build << 16) + revision;
        }
    }
}
