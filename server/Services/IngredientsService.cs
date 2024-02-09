
namespace AllSpice.Services;

public class IngredientsService(IngredientsRepository repo, RecipesService recipesService)
{
    private readonly IngredientsRepository repo = repo;

    // -----------------------------------------------------------

    internal Ingredient Create(Ingredient data, string userId)
    {
        Recipe recipe = recipesService.GetById(data.RecipeId);
        if (recipe.CreatorId != userId)
        {
            throw new Exception("You can not do that");
        }
        return repo.Create(data);
    }

    internal List<Ingredient> getIngredientByRecipeId(int recipeId)
    {
        List<Ingredient> ingredient = repo.getIngredientByRecipeId(recipeId);
        return ingredient;
    }
}