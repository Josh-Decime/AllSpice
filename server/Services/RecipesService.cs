
namespace AllSpice.Services;

public class RecipesService(RecipesRepository repo)
{
    private readonly RecipesRepository repo = repo;

    // -------------------------------------------------

    internal Recipe Create(Recipe recipeData)
    {
        Recipe recipe = repo.Create(recipeData);
        return recipe;
    }

    internal List<Recipe> GetAll()
    {
        List<Recipe> recipes = repo.GetAll();
        return recipes;
    }
}