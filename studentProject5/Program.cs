// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Task 1
var t1 = Task<int>.Run(() => {
    Random rnd = new Random();
    int nomerRandom = rnd.Next(1, 4);
    return nomerRandom;
});

t1.Wait();

var nomerRandom = t1.Result;
Console.WriteLine("Angka random 1 yang dihasilkan: {0}", nomerRandom);

switch (nomerRandom) 
{
    case 1:
        Task1();
        break;
    case 2:
        Task2();
        break;
    case 3:
        Task3();
        break;
}
// Task 1
void Task1()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 1")
    ).Wait();
  
}
// Task 2
void Task2()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 2")
    ).Wait();
}
// Task 3
void Task3()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 3")
    ).Wait();
}


// Task 2
var t2 = Task<int>.Run(() => {
    Random rnd = new Random();
    int nomerRandom2 = rnd.Next(1, 4);
    return nomerRandom2;
});

t2.Wait();

var nomerRandom2 = t2.Result;

Console.WriteLine("Angka random 2 yang dihasilkan: {0}", nomerRandom2);

switch (nomerRandom2)
{
    case 1:
        Task4();
        break;
    case 2:
        Task5();
        break;
    case 3:
        Task6();
        break;
}
// Task 1
void Task4()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 1")
    ).Wait();
  
}
// Task 2
void Task5()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 2")
    ).Wait();
}
// Task 3
void Task6()
{
    Task.Run(() =>
        Console.WriteLine("Menjalkankan task 3")
    ).Wait();
}


// Task 3
var t3 = Task<int>.Run(() =>{
    int hasil = nomerRandom + nomerRandom2;
    return hasil;
});

t3.Wait();

var hasil = t3.Result;

Console.WriteLine("Hasil akhir: {0}", hasil);