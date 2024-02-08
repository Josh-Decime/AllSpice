namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly RecipesService recipesService;
    private readonly Auth0Provider auth;
    public RecipesController(Auth0Provider auth, RecipesService recipesService)
    {
        this.auth = auth;
        this.recipesService = recipesService;
    }

    // ---------------------------------------

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> Create([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = recipesService.Create(recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetById(int recipeId)
    {
        try
        {
            Recipe recipe = recipesService.GetById(recipeId);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAll()
    {
        try
        {
            List<Recipe> recipes = recipesService.GetAll();
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{recipeId}")]
    public ActionResult<Recipe> Update([FromBody] Recipe updateData, int recipeId)
    {
        try
        {
            updateData.Id = recipeId;
            Recipe update = recipesService.Update(updateData);
            return Ok(update);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    public ActionResult<string> Delete(int recipeId)
    {
        try
        {
            string message = recipesService.Delete(recipeId);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}