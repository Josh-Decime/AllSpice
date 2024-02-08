namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService ingredientsService;
    private readonly Auth0Provider auth;
    // private readonly RecipesService recipesService;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
        this.ingredientsService = ingredientsService;
        this.auth = auth;
        // this.recipesService = recipesService;
    }

    // ------------------------------------------------------------------------------------

    [HttpPost]
    [Authorize]
    // TODO would be nice to have an authorization check
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            // creatorId = recipesService.GetById(ingredientData.RecipeId)
            // ingredientData.RecipeId = userInfo.Id;
            Ingredient ingredient = ingredientsService.Create(ingredientData, userInfo.Id);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}