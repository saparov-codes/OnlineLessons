using System.Text.Json;
using ExamVariant1.DataAccess.Entities;

namespace ExamVariant1.Repositories;

public class MusicRepository : IMusicRepository
{
    private readonly string _filePath = "../../../DataAccess/Data/music.json";
    private List<Music> _musics;

    public MusicRepository()
    {
        _musics = new List<Music>();

        if (File.Exists(_filePath) is false)
        {
            File.WriteAllText(_filePath, "[]");
        }
    }

    public void AddMusic(Music music)
    {
        _musics.Add(music);
        SaveChanges();
    }

    public List<Music> GetAllMusic()
    {
        var musicsJson = File.ReadAllText(_filePath);
        var musicsList = JsonSerializer.Deserialize<List<Music>>(musicsJson);
        return musicsList;
    }

    public List<string> GetAllUniqueAuthors()
    {
        var uniqueAuthors = new List<string>();

        foreach (var music in _musics)
        {
            var count = 0;
            for (var i = 0; i < _musics.Count; i++)
            {
                if(music.Name == _musics[i].Name)
                {
                    count++;
                }
            }
            if(count == 1)
            {
                uniqueAuthors.Add(music.Name);
            }
            
        }
        return uniqueAuthors;
    }

    public List<Music> GetMusicAboveSize(double minSize)
    {
        var longMusics = new List<Music>();
        foreach (var music in _musics)
        {
            if (music.MB > minSize)
            {
                longMusics.Add(music);
            }
        }

        return longMusics;
    }

    public List<Music> GetMusicByAuthor(string authorName)
    {
        var musicsByAuthor = new List<Music>();

        foreach (Music music in _musics)
        {
            if (music.AuthorName == authorName)
            {
                musicsByAuthor.Add(music);
            }
        }

        return musicsByAuthor;
    }

    public Music GetMusicByName(string name)
    {
        foreach (var music in _musics)
        {
            if (music.Name == name)
            {
                return music;
            }
        }

        throw new Exception($"Bazada {name} nomli musiqa yuq");
    }

    public double GetTotalMusicSizeByAuthor(string authorName)
    {
        var totalMusicSize = 0d;
        foreach(var music in _musics)
        {
            if(music.AuthorName == authorName)
            {
                totalMusicSize += music.MB;
            }
        }

        return totalMusicSize;
    }

    public void SaveChanges()
    {
        var musicsJson = JsonSerializer.Serialize(_musics);
        File.WriteAllText(_filePath, musicsJson);
    }
}
