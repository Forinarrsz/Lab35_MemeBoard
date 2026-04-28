namespace MemesApi.Models;

public class Meme 
{
    public int Id {get; set;}
    public int Rating {get; set;} =1;
    public string Title {get; set;} = string.Empty;
    public string Category {get; set;} = string.Empty;
    public DateTime AddedAt {get; set;} = DateTime.UtcNow;

}