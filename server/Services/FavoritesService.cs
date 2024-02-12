


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

    internal string DeleteFavorite(int favoriteId, string id)
    {
        throw new NotImplementedException();
    }

    internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
    {
        List<FavoriteRecipe> favoriteRecipes = repo.GetAccountFavoriteRecipes(userId);
        return favoriteRecipes;
    }
}