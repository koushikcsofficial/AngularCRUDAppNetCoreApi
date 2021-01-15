import { EventEmitter } from "@angular/core";
import { Recipe } from "./recipe.model";

export class RecipeService{

    recipeSelected = new EventEmitter<Recipe>();

    private recipes:Recipe[] =[
        new Recipe('test 1', 'description 1', 'https://th.bing.com/th/id/R28316494c75a6045d3df671ea77aaa8e?rik=hG6C%2fQy6GIGQxg&riu=http%3a%2f%2fnovasiagsis.com%2fwp-content%2fuploads%2f2019%2f11%2fimage1.jpg'),
        new Recipe('test 2', 'description 2','https://cdn.diys.com/wp-content/uploads/2018/01/Mediterranean-Loaded-Baked-Potato-Recipe.jpg'),
        new Recipe('test 3','description 3','https://cafedelites.com/wp-content/uploads/2017/11/Browned-Butter-Honey-Garlic-Salmon-IMAGE-1.jpg'),
        new Recipe('test 4','description 4','https://valentinascorner.com/wp-content/uploads/2019/04/Chilli-Recipe-9825-min.jpg')
      ];

    getRecipes(){
        return this.recipes.slice();
    }
}