using ExamVariant1.DataAccess.Entities;
using ExamVariant1.Repositories;

namespace ExamVariant1;

internal class Program
{
    static void Main(string[] args)
    {
        Music music1 = new Music()
        {
            Name = "Hello",
            AuthorName = "Mehroj",
            Description = "world"
        };

        Music music2 = new Music()
        {
            Name = "Hello",
            AuthorName = "Saparov",
            QuentityLikes = 9
        };

        Music music3 = new Music()
        {
            Name = "Hello",
            AuthorName = "Saparov",
            QuentityLikes = 3,
            Description = "Yaxshi"
        };

        Console.WriteLine("Welcome To The Music Area!");

        Console.WriteLine("1. Add Music");
        Console.WriteLine("2. Search By name");
        Console.WriteLine("3. Search By author");
        Console.WriteLine("4. Delete Music");
        Console.WriteLine("5. See All musics list");

        Console.Write("Option : ");
        var opption = Console.ReadLine();

        MusicRepository musicRepo = new MusicRepository();

        musicRepo.AddMusic(music1);
        musicRepo.AddMusic(music3);
        musicRepo.AddMusic(music2);
        if(opption == "1")
        {
            Music musicName = new Music();
            
            Guid id = Guid.NewGuid();
            musicName.Id = id;
            Console.Write("Music Name : ");
            musicName.Name = Console.ReadLine();
            Console.WriteLine("Author of the Music : ");
            musicName.AuthorName = Console.ReadLine();


            musicRepo.AddMusic(musicName);
            
        }
        else if(opption == "5")
        {
            musicRepo.GetAllMusic().ForEach(music => Console.WriteLine( music.Name));
        }
    }
}
