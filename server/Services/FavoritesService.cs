


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

    internal string DeleteFavorite(int favoriteId, string userId)
    {
        Favorite original = repo.GetFavoriteById(favoriteId);
        if (original == null) throw new Exception($"No favorite at id: {favoriteId}");
        if (original.AccountId != userId) throw new Exception("Not yours to delete");
        repo.Delete(favoriteId);
        return $"{favoriteId} was deleted";
    }

    internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
    {
        List<FavoriteRecipe> favoriteRecipes = repo.GetAccountFavoriteRecipes(userId);
        return favoriteRecipes;
    }
}