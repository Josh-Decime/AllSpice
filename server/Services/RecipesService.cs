

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

    internal Recipe GetById(int recipeId)
    {
        Recipe recipe = repo.GetById(recipeId);
        if (recipe == null) throw new Exception($"No recipe at id: {recipeId}");
        return recipe;
    }

    internal Recipe Update(Recipe updateData)
    {
        Recipe original = GetById(updateData.Id);

        original.Title = updateData.Title ?? original.Title;
        original.Instructions = updateData.Instructions ?? original.Instructions;
        original.Img = updateData.Img ?? original.Img;
        original.Category = updateData.Category ?? original.Category;

        Recipe update = repo.Update(original);
        return update;
    }

    internal string Delete(int recipeId)
    {
        Recipe original = GetById(recipeId);
        repo.Delete(recipeId);
        return $"{original.Title} has been deleted!";
    }
}