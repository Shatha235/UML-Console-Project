using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UML_Console_Project;

namespace UML_Console_Project.ProjectFiles
{
    [Serializable]
    class User
    {
        protected string Name;
        protected string Password;

    }
}
