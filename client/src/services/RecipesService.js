import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { logger } from "../utils/Logger.js";
import { api } from "./AxiosService.js";

class RecipesService {
    async getAllRecipes() {
        const response = await api.get('api/recipes')
        logger.log('response data:', response.data)
        AppState.recipes = response.data.map(recipe => new Recipe(recipe))
    }
}

export const recipesService = new RecipesService()