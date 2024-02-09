namespace AllSpice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FavoritesController : ControllerBase
{
    private readonly FavoritesService favoritesService;
    private readonly Auth0Provider auth;

    public FavoritesController(FavoritesService favoritesService, Auth0Provider auth)
    {
        this.favoritesService = favoritesService;
        this.auth = auth;
    }

    // -------------------------------------------------------------------
}