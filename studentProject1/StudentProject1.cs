void Display()
{
    Console.Clear();
    Console.WriteLine("Selamat datang di toko kami");
    Console.WriteLine("\t 1. Tambah produk");
    Console.WriteLine("\t 2. Edit produk");
    Console.WriteLine("\t 3. Tampilkan semua produk");
    Console.WriteLine("\t 4. Hapus produk");
    Console.WriteLine("\t 5. Keluar");
    Console.Write("Pilihan ? : ");
}
var keluar = false;
var produk = new List<string>();

while(!keluar)
{
    Display();
    var pilihan = Console.ReadLine();
    switch(pilihan)
    {
        case "1":
            Console.Write("Tambah produk: ");
            string namaProduk = Console.ReadLine();
            produk.Add(namaProduk);
            Console.WriteLine("Produk telah ditambahkan!");
            break;
        case "2":
            Console.Write("Masukkan index Produk yang akan diedit: ");
            int editIndex = int.Parse(Console.ReadLine());
            if (editIndex < 0 || editIndex >= produk.Count)
            {
                Console.WriteLine("Index tidak valid.");
                break;
            }
            Console.Write("Masukkan nama produk yang baru: ");
            string produkBaru = Console.ReadLine();
            produk[editIndex] = produkBaru;
            Console.WriteLine("Produk telah diubah");
            break;
        case "3":
            Console.WriteLine("Index\t Nama Produk");
            var index = 0;
            foreach(var item in produk)
            {
                Console.WriteLine("{0}\t{1}", index, item);
                index++;
            }
            Console.ReadLine();
            break;
        case "4":
            Console.Write("Masukkan indeks produk yang akan dihapus: ");
            int hapusProduk = int.Parse(Console.ReadLine());
            if(hapusProduk < 0 || hapusProduk >= produk.Count)
            {
                Console.WriteLine("Indeks tidak valid.");
                break;
            }
            produk.RemoveAt(hapusProduk);
            Console.WriteLine("Produk telah dihapus");
            break;
        case "5":
            Console.WriteLine("Keluar");
            keluar = true;
            break;
    }
}