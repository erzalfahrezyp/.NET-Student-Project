EventProduct e = new EventProduct();
e.ProcessCompleted += OnProses;
 
void OnProses(object sender, string pesan)
{
        Console.WriteLine(pesan);
}
 
void Display()
{
    Console.Clear();
    Console.WriteLine("\nSelamat datang di toko kami");
    Console.WriteLine("===========================");
    Console.WriteLine("1. Tambah produk");
    Console.WriteLine("2. Edit produk");
    Console.WriteLine("3. Show list produk");
    Console.WriteLine("4. Hapus produk");
    Console.WriteLine("5. Keluar");
    Console.WriteLine("===========================");
    Console.Write("Masukkan pilihan : ");
}
 
var keluar = false;
var products = new List<Product>();
while(!keluar)
{
    Display();
 
 
 
    string pilihan = Console.ReadLine();
    switch(pilihan)
    {
 
        case "1" :
            // Console.WriteLine("Memulai prosess ...");
            e.Trigger("\nTambah produk");
            Console.WriteLine("==============");
            Console.Write("Masukan SKU:\n ");
            string sku = Console.ReadLine();
 
            // Cek produk
            if(products.Any(prod => prod.Sku == sku )){
                Console.WriteLine("Kode produk {0} sudah ada", sku);
                Console.ReadLine();
                break;
            }
 
            // Jika tidak ada
            Console.WriteLine("Masukan Nama: ");
            string nama = Console.ReadLine();
            Console.Write("Masukan Harga:\n ");
            string harga = Console.ReadLine();
 
            double hargaDouble = Double.Parse(harga);
 
            // Buat objek Product baru dengan constructor
            Product produkBaru = new Product(sku, nama, hargaDouble);
            products.Add(produkBaru);
 
            Console.WriteLine("===========================");
            e.Trigger("Produk berhasil ditambahkan");
            Console.ReadLine();
            break;
        case "2" :
            e.Trigger("\nEdit produk");
            // Console.WriteLine("Edit data produk");
            Console.WriteLine("==============");
            Console.Write("Masukan SKU: ");
            string skuEdit = Console.ReadLine();
 
            Product editProduk = products.Find(pEdit => pEdit.Sku == skuEdit);
 
            // Jika sku yang dimasukan tidak kosong
            if(editProduk != null)
            {
                Console.Write("Masukkan Nama baru: ");
                string namaEdit = Console.ReadLine();            
                Console.Write("Masukan Harga baru: ");
                string hargaEdit = Console.ReadLine();
                double editDouble = Double.Parse(hargaEdit);
                editProduk.Nama = namaEdit;
                editProduk.Harga = editDouble;
 
                Console.WriteLine("=======================");
                //Console.WriteLine("Produk berhasil di edit");
                e.Trigger("Produk berhasil diedit");
            }
            else
            {
                Console.WriteLine("=============================");
                //Console.WriteLine("Sku yang dimasukkan tidak ada");
                e.Trigger("SKU yang dimasukkan tidak ada");
            }
 
            Console.ReadLine();
            break;
        case "3": 
            e.Trigger("\nDaftar Produk");
            // Console.WriteLine("Daftar list produk");
            Console.WriteLine("==============");
            if(products.Count > 0){
                foreach(var index in products)
                {
                    Console.WriteLine("SKU: {0}", index.Sku);
                    Console.WriteLine("Nama: {0}", index.Nama);
                    Console.WriteLine("Harga: {0}", index.Harga);
                    Console.WriteLine("==============");
                }
 
            }
            else
            {
                Console.WriteLine("===========================");
                //Console.WriteLine("Daftar produk masih kosong");
                e.Trigger("Daftar produk masih kosong");
            }
 
            Console.ReadLine();
            break;
        case "4":
            e.Trigger("\nHapus produk");
            // Console.WriteLine("Hapus data produk");
            Console.WriteLine("==============");
            Console.Write("Masukan SKU: ");
            string skuHapus = Console.ReadLine();
 
            // Cari sku yang ingin di hapus di dalam products
            var hapusProduk = products.Find(prodHapus => prodHapus.Sku == skuHapus);
 
            if(hapusProduk != null)
            {
                products.Remove(hapusProduk);
                Console.WriteLine("========================================");
                Console.WriteLine("Produk dengan kode {0} berhasil di hapus", hapusProduk);
            }
            else
            {
                Console.WriteLine("======================================");
                Console.WriteLine("Produk dengan kode {0} tidak ditemukan", skuHapus);
            }
 
            Console.ReadLine();
            break;
        case "5":
            //Console.WriteLine("Keluar");
            Console.WriteLine("\n============================");
            e.Trigger("Terimakasih telah berkunjung");
            Console.WriteLine("============================");
            keluar = true;
            break;
        default:
            Console.WriteLine("=================");
            //Console.WriteLine("Pilihan tidak ada");
            e.Trigger("Pilihan tidak ada");
            break;
    }
}
 
