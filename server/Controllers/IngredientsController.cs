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


}