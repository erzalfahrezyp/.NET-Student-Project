public class Product
{
    // Sku Unik, Nama, Harga
    public string Sku { get; set; }
    public string Nama { get; set; }
    public double Harga { get; set; }
 
 
    // Cunstructor
    public Product(string sku, string nama, double harga)
    {
        Sku = sku;
        Nama = nama;
        Harga = harga;
    }
}