namespace amocrm.library.Tools
{
    internal class FilterNameRepresentAttribute : System.Attribute
    {
        public string Name { get; set; }

        public FilterNameRepresentAttribute(string name) => Name = name;
    }
}