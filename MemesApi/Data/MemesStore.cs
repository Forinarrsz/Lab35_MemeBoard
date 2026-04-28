using MemesApi.Models;
namespace MemesApi.Data;

public static class MemesStore {
    private static int _nextId = 4;
    public static List<Meme> Memes {get;} = new() { 
        new Meme {
            Id = 1, Title = "Meme 1", Category = "meme 1", Rating = 5,
            AddedAt = new DateTime(2026, 1,1,0,0,0, DateTimeKind.Utc)
        },
                new Meme {
            Id = 2, Title = "Meme 2", Category = "meme 2", Rating = 3,
            AddedAt = new DateTime(2026, 1,2,0,0,0, DateTimeKind.Utc)
        },
                new Meme {
            Id = 3, Title = "Meme 3", Category = "meme 3", Rating = 5,
            AddedAt = new DateTime(2026, 1,3,0,0,0, DateTimeKind.Utc)
        },

    };

    public static int NextId() => _nextId++;
}