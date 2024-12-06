using System.ComponentModel.Design;
using System.Net.Security;

var ToDos = new List<string>();
bool çıkışYapılcak = false;
while (!çıkışYapılcak)


    {
        Console.WriteLine("");
        Console.WriteLine("Merhaba");
        Console.WriteLine("Ne yapmak istiyorsun?");
        Console.WriteLine("1. Yapılcakları gör");
        Console.WriteLine("2. Yapılcak ekle");
        Console.WriteLine("3. Yapılacak çıkar");
        Console.WriteLine("4. Çıkış");

        var kullanıcıGirdisi = Console.ReadLine();

        switch (kullanıcıGirdisi)
        {
            case "1":
            seeAllToDos();
                break;
            case "2":
            addAToDo();
                break;
            case "3":
            removeToDo();
                break;
            case "4":
                Console.WriteLine("Çıkış");
                çıkışYapılcak = true;
                break;
            default:
                Console.WriteLine("Geçersiz işlem");
                break;
        }
    }


void removeToDo()
{
    if (ToDos.Count == 0)
    {
        Console.WriteLine("Yapılacak bir şey yok");
        return;
    }
    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Kaldırmak istediğiniz işlemin numarasını seçin");
        seeAllToDos();
        var kullanıcıGirdisi = Console.ReadLine();
        if (kullanıcıGirdisi == "")
        { Console.WriteLine("Seçtiğin işlem boş olamaz");
        continue;
        }
        if (int.TryParse(kullanıcıGirdisi, out int index))
        {
            if (index > 0 && index <= ToDos.Count)
            {
                ToDos.RemoveAt(index - 1);
                Console.WriteLine("İşlem kaldırıldı");
                isIndexValid = true;
            }
            else
            {
                Console.WriteLine("Geçersiz numara");
            }
        }
        else
        {
            Console.WriteLine("Geçersiz numara");
        }
    }
}

void seeAllToDos()
{
    if (ToDos.Count == 0)
    {
        Console.WriteLine("Yapılacak bir şey yok");
    }
    else
    {
        for (int i = 0; i < ToDos.Count; i++)
        {

            Console.WriteLine($"{i+1}. {ToDos[i]}");
        }
    }
}

void addAToDo()
{
    var açıklamaDüzgünMü = false;
    while (!açıklamaDüzgünMü)
    {

        Console.WriteLine("Lütfen açıklama ekleyiniz:");
        var açıklama = Console.ReadLine();

        if (açıklama == "")
        {
            Console.WriteLine("Açıklama boş olamaz");
        }
        else if (ToDos.Contains(açıklama))
        {
            Console.WriteLine("Bu açıklama zaten var");
        }
        else
        {
            açıklamaDüzgünMü = true;
            ToDos.Add(açıklama);
            Console.WriteLine("Açıklama eklendi");


        }
    }
}