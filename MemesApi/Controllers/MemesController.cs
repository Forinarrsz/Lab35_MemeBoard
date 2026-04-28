[ApiController]
[Route("api/[controller]")]
public class MemesController : controllerBase { 
    [HttpGet]
    public ActionResult<List<Meme>> GetAll() {
        return Ok(MemesStore.Memes);
    }
    [HttpGet("{id}")]
    public ActionResult<Meme> GetById(int id) {
        var meme = MemesStore.Memes.FirstOfDefault( m => m.Id == id);

        if (meme is null) {
            return NotFound(new {message = $"Meme with id {id} not found"});
        }
        return Ok(meme);
    }

    [HttpPost]
    public ActionResult<Meme> Create([FromBody] Meme meme) {
        if (string.IsNullOrWhiteSpace(meme.Title)) {
            return BadRequest(new {message = "title not be empty"});
        }
        if (meme.Rating < 1 || meme.Rating > 5) {
            return BadRequest (new { message = "Rating should be 1 to 5"});
        }
        meme.Id = MemesStore.NextId();
        meme.AddedAt = DateTime.UtcNow;
        MemesStore.Memes.Add(meme);
        return CreatedAtAcion(nameof(GetById), new {id = meme.Id}, meme);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id) {
        var meme = MemesStore.Memes.FirstOfDefault(m => m.Id == id);
        if (meme.Rating < 1 || meme.Rating > 5) {
            return BadRequest (new { message = $"meme with id {id} not found"});
    }
    MemesStore.Memes.Remove(meme);
    return NoContent();
}