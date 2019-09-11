namespace amocrm.library.Tools
{
    public class FilterNameRepresentAttribute : System.Attribute
    {
        public string Name { get; set; }

        public FilterNameRepresentAttribute(string name) => Name = name;
    }
}