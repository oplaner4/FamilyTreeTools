using System.Text.RegularExpressions;

namespace FamilyTreeTools.Utilities.Serialize
{
    public abstract class SerializeHelper
    {
        public SerializeHelper(string fileName, string extension)
        {
            FullFileName = string.Format("{0}.{1}",
                new Regex(@"[\s,:\?\*]+").Replace(
                    fileName,
                    _ => "_"
                ),
                extension
            );
        }

        public string FullFileName { get; private set; }
    }
}
