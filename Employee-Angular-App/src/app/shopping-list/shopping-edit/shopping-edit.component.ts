import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import {Ingredient} from '../../../app/shared/ingredient.model'
import { ShoppingListService } from '../shopping-list.service';

@Component({
  selector: 'app-shopping-edit',
  templateUrl: './shopping-edit.component.html',
  styleUrls: ['./shopping-edit.component.css']
})
export class ShoppingEditComponent implements OnInit {

  @ViewChild('itemNameInput') itemNameInputRef:ElementRef | undefined;
  @ViewChild('amountInput') amountInputRef:ElementRef | undefined;

  constructor(private slService:ShoppingListService) { }

  ngOnInit(): void {
  }

  onAddItem(){
    const newIngredient = new Ingredient(this.itemNameInputRef?.nativeElement.value,this.amountInputRef?.nativeElement.value);
    this.slService.addIngredient(newIngredient);
  }

}
