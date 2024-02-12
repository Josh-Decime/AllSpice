


namespace AllSpice.Repositories;

public class FavoritesRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;


    // ----------------------------------------------------------

    internal FavoriteRecipe CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);

        SELECT
        favorites.*,
        recipes.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = recipes.id
        WHERE favorites.id = LAST_INSERT_ID();
        ";
        FavoriteRecipe favoriteRecipe = db.Query<Favorite, FavoriteRecipe, FavoriteRecipe>(sql, (favorite, recipe) =>
        {
            // favorite.RecipeId = recipe.CreatorId;
            recipe.FavoriteId = favorite.Id;
            return recipe;
        }, favoriteData).FirstOrDefault();
        return favoriteRecipe;
    }

    internal List<FavoriteRecipe> GetAccountFavoriteRecipes(string userId)
    {
        string sql = @"
        SELECT 
        favorites.*,
        recipes.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = recipes.id
        WHERE favorites.accountId = @userId;
        ";
        List<FavoriteRecipe> favoriteRecipes = db.Query<Favorite, FavoriteRecipe, FavoriteRecipe>(sql, (favorite, favoriteRecipe) =>
        {
            favoriteRecipe.FavoriteId = favorite.Id;
            return favoriteRecipe;
        }, new { userId }).ToList();
        return favoriteRecipes;
    }

    public Favorite GetFavoriteById(int favoriteId)
    {
        string sql = @"
        SELECT
        *
        FROM favorites
        WHERE id = @favoriteId;
        ";
        Favorite favorite = db.Query<Favorite>(sql, new { favoriteId }).FirstOrDefault();
        return favorite;
    }

    internal void Delete(int favoriteId)
    {
        string sql = @"
        DELETE FROM favorites WHERE id = @favoriteId
        ";
        db.Execute(sql, new { favoriteId });
    }
}