namespace FamilyTreeTools.Utilities.Serialize
{
    public abstract class SerializeHelper
    {
        public SerializeHelper(string fileName)
        {
            FullFileName = fileName;
        }

        public string FullFileName { get; private set; }
    }
}
