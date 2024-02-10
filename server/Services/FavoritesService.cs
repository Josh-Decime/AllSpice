
namespace AllSpice.Services;

public class FavoritesService(FavoritesRepository repo)
{
    private readonly FavoritesRepository repo = repo;


    // ----------------------------------------------------------

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        FavoriteRecipe favoriteRecipe = repo.CreateFavorite(favoriteData);
        return favoriteRecipe;
    }


}