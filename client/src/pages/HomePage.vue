<template>
  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 card align-items-center shadow rounded elevation-3">
      <img src="https://bcw.blob.core.windows.net/public/img/8600856373152463" alt="CodeWorks Logo"
        class="rounded-circle">
      <h1 class="my-5 bg-dark text-white p-3 rounded text-center">
        Vue 3 Starter
      </h1>
    </div>
  </div> -->
  <section>
    <button @click="getAllRecipes()">All Recipes</button>
    <button>My Recipes</button>
    <button>Favorites</button>
  </section>

  <section class="row">
    <div v-for="recipe in allRecipes" class="col-12 col-md-4">
      <RecipeCard :recipe="recipe" />
    </div>
  </section>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { recipesService } from '../services/RecipesService.js'
import RecipeCard from '../components/RecipeCard.vue';

export default {
  setup() {
    onMounted(() => {
      getAllRecipes(),
        getMyRecipes()
    });
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }

    async function getMyRecipes() {
      try {
        await recipesService.getMyRecipes();
      }
      catch (error) {
        Pop.error(error)
      }
    }


    return {
      allRecipes: computed(() => { return AppState.allRecipes; }),

    };
  },
  components: { RecipeCard }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
