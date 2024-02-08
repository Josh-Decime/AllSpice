
namespace AllSpice.Repositories;

public class RecipesRepository(IDbConnection db) : IRepository<Recipe>
{
    private readonly IDbConnection db = db;

    // --------------------------------------------------------------------

    public Recipe Create(Recipe createData)
    {
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
            recipes.*,
            accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = LAST_INSERT_ID();
        ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, createData).FirstOrDefault();
        return recipe;
    }

    public void Delete(int recipeId)
    {
        string sql = @"
        DELETE FROM recipes
        WHERE id = @recipeId;
        ";
        db.Execute(sql, new { recipeId });
    }

    public List<Recipe> GetAll()
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorID = accounts.id;
        ";
        List<Recipe> recipes = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }

    public Recipe GetById(int recipesId)
    {
        string sql = @"
        SELECT
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @recipesId;
        ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipesId }).FirstOrDefault();
        return recipe;
    }

    public Recipe Update(Recipe updateData)
    {
        string sql = @"
        UPDATE recipes SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;

        SELECT
            recipes.*,
            accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @id;
       ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, updateData).FirstOrDefault();
        return recipe;
    }
}