namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientsController : ControllerBase
{
    private readonly IngredientsService ingredientsService;
    private readonly Auth0Provider auth;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
        this.ingredientsService = ingredientsService;
        this.auth = auth;
    }

    // ------------------------------------------------------------------------------------

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> Create([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            Ingredient ingredient = ingredientsService.Create(ingredientData, userInfo.Id);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{ingredientId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteIngredient(int ingredientId)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = ingredientsService.DeleteIngredient(ingredientId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }



}