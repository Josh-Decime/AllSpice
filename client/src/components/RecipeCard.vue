<template>
    <section @click="getActiveRecipe()" data-bs-toggle="modal" data-bs-target="#recipeModal">
        <section class="row m-2 rounded imgScaling selectable" :style="{ backgroundImage: `url(${recipe.img})` }">
            <div class="d-flex justify-content-between mt-2">
                <div class="textBackdropBlurRound">{{ recipe.category }}</div>
                <div class="textBackdropBlurRound"><i class="mdi mdi-heart"></i></div>
            </div>
            <div class="showImgPadding"></div>
            <div class="textBackdropBlur py-2">{{ recipe.title }}</div>
        </section>
    </section>



    <!-- Modal -->
    <section v-if="activeRecipe">
        <div class="modal fade" id="recipeModal" tabindex="-1" aria-labelledby="recipeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header">
                        <h1 class="modal-title fs-5" id="recipeModalLabel">{{ activeRecipe.title }}</h1>
                        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <section class="col-6">
                                <img :src="`${activeRecipe.img}`" :alt="`Image of ${activeRecipe.title}`" class="img-fluid">
                                <p>{{ activeRecipe.instructions }}</p>
                            </section>
                            <section class="col-6">

                            </section>
                        </div>

                    </div>
                    <div class="modal-footer">
                        <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button> -->
                    </div>
                </div>
            </div>
        </div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe.js';
import { recipesService } from '../services/RecipesService.js';
export default {
    props: { recipe: { type: Recipe, required: true }, activeRecipe: { type: Recipe } },


    setup(props) {

        async function getActiveRecipe() {
            await recipesService.getActiveRecipe(props.recipe.id)
        }

        async function getIngredients() {

        }


        return {
            getActiveRecipe,
            activeRecipe: computed(() => AppState.activeRecipe)

        }
    }
};
</script>


<style lang="scss" scoped>
.showImgPadding {
    padding-top: 250px;
}

.imgScaling {
    background-size: cover;
}

.textBackdropBlur {
    backdrop-filter: blur(25px);
    color: whitesmoke;
    text-shadow: 2px 2px 3px black;
    border-bottom-left-radius: 7px;
    border-bottom-right-radius: 7px;
    // overflow: hidden;
}

.textBackdropBlurRound {
    backdrop-filter: blur(25px);
    color: whitesmoke;
    text-shadow: 2px 2px 3px black;
    border-radius: 15px;
}
</style>