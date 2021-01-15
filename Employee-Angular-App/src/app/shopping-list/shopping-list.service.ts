import { Ingredient } from "../shared/ingredient.model";

export class ShoppingListService{
    private ingredients:Ingredient[] = [
        new Ingredient('Ingredient Name 1',5),
        new Ingredient('Ingredient Name 2',6),
        new Ingredient('Ingredient Name 3',7),
      ];

      getIngredients(){
          return this.ingredients.slice();
      }

      addIngredient(ingredient:Ingredient){
          this.ingredients.push(ingredient);
      }
}