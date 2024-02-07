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


}