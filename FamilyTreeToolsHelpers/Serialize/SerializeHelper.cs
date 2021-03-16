using FamilyTreeTools.Entities;
using Newtonsoft.Json;
using System.IO;

namespace FamilyTreeTools.Utilities.Serialize
{
    public abstract class SerializeHelper
    {
        public SerializeHelper(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; private set; }

        public string GetFullFileName (string extension)
        {
            return string.Format("{0}.{1}", FileName, extension);
        }
    }
}
