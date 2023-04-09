
namespace WinformRopeRounding.Models
{
    public class Product
    {
        public string Catagory { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;        
        public string ModelFiles { get; set; } = string.Empty;
    }

    //public class Products
    //{
    //    private List<Product> Models= new();

    //    public Products() { }

    //    public Products(string jsonString)
    //    {
    //        Models = JsonConvert.DeserializeObject<List<Product>>(jsonString);
    //    }

    //    public void Add(string name, string catagory, string ModelFiles)
    //    {
    //        Models.Add(new Product { Name = name, Catagory = catagory, ModelFiles = ModelFiles });
    //    }

    //    public void Remove(string name)
    //    {
    //        Models.Remove(new Product { Name = name }); 
    //    }
    //    public Product? Get(string name)
    //    {
    //        return Models.FirstOrDefault(x => x.Name == name);
    //    }

    //    public int Count => Models.Count;

    //    public Product this[int index]
    //    {
    //        get { return Models[index]; }
    //    }

    //    public string ToJson()
    //    {
    //        return JsonConvert.SerializeObject(Models, Formatting.Indented);
    //    }
        
    //}

}
