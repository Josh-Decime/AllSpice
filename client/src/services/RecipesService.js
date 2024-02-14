import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {
    async getAllRecipes() {
        const response = await api.get('api/recipes')
        logger.log('All Recipe response data:', response.data)
        AppState.allRecipes = response.data.map(recipe => new Recipe(recipe))
    }

    async getMyRecipes() {
        // let response = await api.get('account/recipes')
        // logger.log('My Recipe response data:', response.data)
        // AppState.myRecipes = response.data.map(recipe => new Recipe(recipe))
        // AppState.myRecipes = AppState.allRecipes.FindAll(recipe => recipe.creatorId == AppState.account.id)
    }

    async getActiveRecipe(recipeId) {
        let response = await api.get(`api/recipes/${recipeId}`)
        let activeRecipe = new Recipe(response.data)
        AppState.activeRecipe = activeRecipe
        logger.log('active recipe:', AppState.activeRecipe)
    }
}

export const recipesService = new RecipesService()