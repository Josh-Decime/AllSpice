
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
       (name, quantity, recipeId)
       VALUES
       (@name, @quantity, @recipeId);

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
}