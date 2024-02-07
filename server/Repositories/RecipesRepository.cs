
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

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public List<Recipe> GetAll()
    {
        throw new NotImplementedException();
    }

    public Recipe GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Recipe Update(Recipe updateData)
    {
        throw new NotImplementedException();
    }
}