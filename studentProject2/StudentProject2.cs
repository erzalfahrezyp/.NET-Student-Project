EventProduct e = new EventProduct();
e.ProcessCompleted += OnProses; // += artinya subscribe, jika -= setelah aktif hilang
 
void OnProses(object sender, string pesan)
{
        Console.WriteLine(pesan);
}

void Display()
{
    Console.Clear();
    Console.WriteLine(" Selamat datang di toko kami");
    Console.WriteLine("=============================");
    Console.WriteLine(" 1. Tambah produk");
    Console.WriteLine(" 2. Edit produk");
    Console.WriteLine(" 3. Tampilkan semua produk");
    Console.WriteLine(" 4. Hapus produk");
    Console.WriteLine(" 5. Keluar");
    Console.WriteLine("=============================");
    Console.Write("Pilihan ? : ");
}

var produk = new List<Produk>();
int pilihan = 0;
while(pilihan != 5)
{
    Display();
    pilihan = int.Parse(Console.ReadLine());
    switch(pilihan)
    {
        case 1:
            garis();
            e.Trigger("||      Tambah Produk      ||");
            garis();
            Console.Write("SKU:\n ");
            string sku = Console.ReadLine();
            if (produk.Any(p => p.SKU == sku))
            {
                garis();
                Console.WriteLine("Kode produk {0} sudah ada", sku);
                Console.ReadLine();
                break;
            }

            Console.Write("Nama:\n ");
            string nama = Console.ReadLine();
            Console.Write("Stock:\n ");
            int stock = int.Parse(Console.ReadLine());
            Console.Write("Harga:\n ");
            int harga = int.Parse(Console.ReadLine());

            produk.Add(new Produk(sku, nama, stock, harga));
            garis();
            //Console.WriteLine("Produk telah ditambahkan.");
            e.Trigger("Produk telah ditambahkan.");
            Console.ReadLine();
            break;
        case 2:
            garis();
            e.Trigger("||       Edit Produk       ||");
            garis();
            Console.Write("SKU:\n ");
            string skuBaru = Console.ReadLine();
            Produk produkLama = produk.Find(p => p.SKU == skuBaru);
            if (produkLama == null)
            {
                garis();
                //Console.WriteLine("Produk tidak ditemukan.");
                e.Trigger("Produk tidaK ditemukan.");
                Console.ReadLine();
                break;
            }
            Console.Write("Nama ({0}):\n ", produkLama.Nama);
            string namaBaru = Console.ReadLine();
            if (!string.IsNullOrEmpty(namaBaru))
            {
                produkLama.Nama = namaBaru;
            }
            Console.Write("Stock ({0}):\n ", produkLama.Stock);
            string stockStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(stockStr))
            {
                int stockBaru = int.Parse(stockStr);
                produkLama.Stock = stockBaru;
            }
            Console.Write("Harga ({0}):\n ", produkLama.Harga);
            string hargaStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(hargaStr))
            {
                int hargaBaru = int.Parse(hargaStr);
                produkLama.Stock = hargaBaru;
            }
            garis();
            e.Trigger("Produk berhasil diupdate.");
            Console.ReadLine();
            break;
        case 3:
            garis();
            e.Trigger("||      Daftar Produk      ||");
            garis();
            foreach(var item in produk)
            {
                Console.WriteLine("SKU: {0}\nNama: {1}\nStock: {2}\nHarga: {3}", item.SKU, item.Nama, item.Stock, item.Harga);
                garis();
            }
            Console.ReadLine();
            break;
        case 4:
            garis();
            e.Trigger("||      Hapus Produk       ||");
            garis();
            Console.Write("SKU:\n ");
            string skuHapus = Console.ReadLine();
            Produk produkHapus = produk.Find(p => p.SKU == skuHapus);
            if (produkHapus == null)
            {
                garis();
                e.Trigger("Produk tidak ditemukan.");
                Console.ReadLine();
                break;
            }
            produk.Remove(produkHapus);
            garis();;
            e.Trigger("Produk berhasil dihapus.");
            Console.ReadLine();
            break;
        case 5:
            garis();
            e.Trigger("Terimakasih telah berkunjung.");
            garis();
            
            break;
        default:
            garis();
            //Console.WriteLine("Pilihan tidak valid.");
            e.Trigger("Pilihan tidak valid.");
            Console.ReadLine();
            break;
    }
}

void garis()
{
    Task.Run(() =>
        Console.WriteLine("=============================")
    ).Wait();
  
}