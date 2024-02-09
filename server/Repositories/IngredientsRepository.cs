


namespace AllSpice.Repositories;

public class IngredientsRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;


    // -----------------------------------------------------

    // TODO cant build this until I have the ingredient table in MySQL
    internal Ingredient Create(Ingredient ingredientData)
    {
        string sql = @"
       INSERT INTO ingredients
       (name, quantity, recipeId, creatorId)
       VALUES
       (@name, @quantity, @recipeId, @creatorId);

       SELECT
        ingredients.*,
        recipes.*
       FROM ingredients
       JOIN recipes ON ingredients.recipeId = recipes.id
       WHERE ingredients.id = LAST_INSERT_ID();
       ";
        Ingredient ingredient = db.Query<Ingredient, Recipe, Ingredient>(sql, (ingredient, recipe) =>
        {
            ingredient.RecipeId = recipe.Id;
            return ingredient;
        }, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> getIngredientByRecipeId(int recipeId)
    {
        string sql = @"
        SELECT
        ingredients.*
        FROM ingredients
        WHERE ingredients.recipeId = @recipeId;
        ";
        List<Ingredient> ingredients = db.Query<Ingredient>(sql, new { recipeId }).ToList();
        return ingredients;
    }

    public Ingredient GetIngredientById(int ingredientId)
    {
        string sql = @"
        SELECT
        ingredients.*
        FROM ingredients
        WHERE ingredients.id = @ingredientId;
        ";
        Ingredient ingredient = db.Query<Ingredient>(sql, new { ingredientId }).FirstOrDefault();
        return ingredient;
    }

    internal void DeleteIngredient(int ingredientId)
    {
        string sql = @"
        DELETE FROM ingredients
        WHERE ingredients.id = @ingredientId;
        ";
        db.Execute(sql, new { ingredientId });
    }
}