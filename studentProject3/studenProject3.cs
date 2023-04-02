public class Program
{
    static void Main(string[] args)
    {
        List<Pegawai> listPegawai = new List<Pegawai>();
        listPegawai.Add(new Pegawai(){Id = 1, Nama = "Joko", Email = "joko@mail.com", Alamat = "Jl. Mundur", Kota = "Jakarta"});
        listPegawai.Add(new Pegawai(){Id = 2, Nama = "Dewi", Email = "dewi@mail.com", Alamat = "Jl. Aja", Kota = "Bandung"});
        listPegawai.Add(new Pegawai(){Id = 3, Nama = "Acel", Email = "acel@mail.com", Alamat = "Jl. Lurus", Kota = "Bekasi"});
        listPegawai.Add(new Pegawai(){Id = 4, Nama = "Bayu", Email = "bayu@mail.com", Alamat = "Jl. Maju", Kota = "Surabaya"});
        listPegawai.Add(new Pegawai(){Id = 5, Nama = "Budi", Email = "budi@mail.com", Alamat = "Jl. Jalan", Kota = "Surabaya"});

        SearchingDelegate search = delegate(Pegawai pegawai, string keyword)
        {
            if (pegawai.Nama.ToLower().Contains(keyword.ToLower()) ||
                pegawai.Email.ToLower().Contains(keyword.ToLower()) ||
                pegawai.Alamat.ToLower().Contains(keyword.ToLower()) ||
                pegawai.Kota.ToLower().Contains(keyword.ToLower()))
            {
                return true;
            }
            else
            {
                return false;
            }
        };

        Console.Write("Masukkan keyword pencarian: ");
        string keyword = Console.ReadLine();

        List<Pegawai> result = listPegawai.FindAll(pegawai => search(pegawai, keyword));

        Console.WriteLine("\n  Hasil Pencarian:");
        Console.WriteLine("====================");
        foreach (var pegawai in result)
        {
            Console.WriteLine("Id: {0}\nNama: {1}\nEmail: {2}\nAlamat: {3}\nKota: {4}", pegawai.Id, pegawai.Nama, pegawai.Email, pegawai.Alamat, pegawai.Kota);
            Console.WriteLine("====================");
        }

        Console.ReadLine();   
        return;
    }
}

    
public class Pegawai
{
    public int Id { get; set; }
    public string Nama { get; set; }
    public string Email { get; set; }
    public string Alamat { get; set; }
    public string Kota { get; set; }
}

    
delegate bool SearchingDelegate(Pegawai pegawai, string keyword);

