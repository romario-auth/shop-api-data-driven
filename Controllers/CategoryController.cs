using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;

[Route("categories")]
public class CategoryController : ControllerBase
{

    [HttpGet]
    [Route ("")]
    public async Task<ActionResult<List<Category>>> Get()
    {
        return new List<Category>();
    }

    [HttpGet]
    [Route ("{id:int}")]
    public async Task<ActionResult<Category>> GetById(int id)
    {
        return new Category();
    }

    [HttpPost]
    [Route ("")]
    public async Task<ActionResult<List<Category>>> Post(
        [FromBody]Category model,
        [FromServices]DataContext context
    )
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        try
        {
            context.Categories.Add(model);
            await context.SaveChangesAsync();
            return Ok(model);
        }
        catch
        {            
            return BadRequest(new { message = "Não foi possível criar a categoria"});
        }
    }

    [HttpPut]
    [Route ("{id}")]
    public async Task<ActionResult<List<Category>>> Put(int id, [FromBody]Category model)
    {
        // Verifica se o Id infomado é o mesmo do modelo
        if(id != model.Id)
            return NotFound(new { message = "Categoria não encontrada"});

        // Verifica se os dados são válidos
        if(!ModelState.IsValid)
            return BadRequest(ModelState);
        
        return Ok(model);
    }

    [HttpDelete]
    [Route ("{id}")]
    public async Task<ActionResult<List<Category>>> Delete(int id)
    {
        return Ok();
    }
}