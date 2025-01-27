using ExamVariant1.DataAccess.Entities;

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
    }
}
