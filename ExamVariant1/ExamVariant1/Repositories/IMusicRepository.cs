using ExamVariant1.DataAccess.Entities;

namespace ExamVariant1.Repositories;

public interface IMusicRepository
{
    void AddMusic(Music music);
    List<Music> GetAllMusic();
    Music GetMusicByName(string name);
    void SaveChanges();
    List<Music> GetMusicByAuthor(string authorName);
    List<Music> GetMusicAboveSize(double minSize);
    List<string> GetAllUniqueAuthors();
    double GetTotalMusicSizeByAuthor(string authorName);
}