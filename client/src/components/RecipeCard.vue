<template>
    <section class="row m-2 rounded imgScaling" :style="{ backgroundImage: `url(${recipe.img})` }">
        <div class="justify-content-end "><i class="mdi mdi-heart"></i></div>
        <div>{{ recipe.category }}</div>
        <div class="showImgPadding"></div>
        <div class="textBackdropBlur">{{ recipe.title }}</div>
    </section>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe.js';
export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped>
.showImgPadding {
    padding-top: 200px;
}

.imgScaling {
    background-size: cover;
}

.textBackdropBlur {
    backdrop-filter: blur(25px);
    color: whitesmoke;
    text-shadow: 2px 2px 3px black;
}
</style>