namespace Crm.Service.Tools
{
    public class FilterNameRepresentAttribute : System.Attribute
    {
        public string Name { get; set; }

        public FilterNameRepresentAttribute(string name) => Name = name;
    }
}