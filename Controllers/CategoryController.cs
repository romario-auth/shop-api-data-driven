using Microsoft.AspNetCore.Mvc;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [HttpGet]
    [Route ("{id:int}")]
    public string GetById(int id)
    {
        return "GET "  + id.ToString();
    }

    [HttpPost]
    [Route ("")]
    public string Post()
    {
        return "POST";
    }

    [HttpPut]
    [Route ("")]
    public string Put()
    {
        return "PUT";
    }

    [HttpDelete]
    [Route ("")]
    public string Delete()
    {
        return "DELETE";
    }
}