import { Component, OnInit } from '@angular/core';
import { AnimalsService, IAnimal, IFamily } from '../services/animals.service';
import { forEach } from '@angular/router/src/utils/collection';
import { Console } from '@angular/core/src/console';
@Component({
  selector: 'app-animals-list',
  templateUrl: './animals-list.component.html',
  styleUrls: ['./animals-list.component.css']
})
export class AnimalsListComponent implements OnInit {

  constructor(private svc: AnimalsService) {
  }

  ngOnInit()
  {
    this.IMG_URL = this.svc.IMG_URL;
    this.SearchAnimals()
  }
  IMG_URL: string;
  CurrentFamilySelection: string = "All";
  Sort: string = "name";
  Order: string = "";
  Family: string = "";
  CurrentPage: number = 1;
  PageLength: number = 500;
  SortDir: string = "asc";
  ConversationStatus: string = "";
  CurrentStatus: string = "All"
  CurrentOrder : string = "All"
  AnimalList: IAnimal[];
  Animal: IAnimal;
  HasMatch: boolean;
  SelectionsFamily: string[] = ["All", "Felidae", "Canidae", "Elephantidae"]
  SelectionsOrder: string[] = ["All", "Carnivora", "Proboscidea"]
  SelectionsStatus: string[] = ["All", "Domesticated", "Not Endangered", "Endangered","Vulnerable"]
  Pages: number[];
  TotalPages: number;
  amountOfAnimals: number;
  SearchAnimals()
  {
    this.svc.GetAnimalsList(this.Sort, this.Order, this.CurrentFamilySelection, this.CurrentPage = 0, this.PageLength, this.SortDir, this.ConversationStatus).subscribe((result =>
    {
      console.table(result)
      this.AnimalList = result.animal
    }))
  }
  ChangeSelection() {
    this.CurrentPage = 0
    this.SearchAnimals()
  }
  GetMovie(ii: number) {
   
  }
  SortOnFamily()
  {
    if (this.Sort == "family") {
      this.ChangeOrder()
    }
    else {
      this.Sort = "family";
    }
    this.SearchAnimals()
  }
  SortOnOrder() {
    if (this.Sort == "order") {
      this.ChangeOrder()
    }
    else {
      this.Sort = "order";
    }
    this.SearchAnimals()
  }
  SortOnName() {
    if (this.Sort == "name") {
      this.ChangeOrder()
    }
    else {
      this.Sort = "name";
    }
    this.SearchAnimals()
  }
  SortOnConservation() {
    if (this.Sort == "conservationstatus") {
      this.ChangeOrder()
    }
    else {
      this.Sort = "conservationstatus";
    }
    this.SearchAnimals()
  }
  ChangeOrder()
  { 
    if(this.SortDir = "asc")
      {
      this.SortDir = "desc"
    }
    else {
      this.SortDir = "asc"
    }
    this.SearchAnimals()
  }
  ChangePage() {
    this.CurrentPage = -1;
    this.SearchAnimals()
  }
}



