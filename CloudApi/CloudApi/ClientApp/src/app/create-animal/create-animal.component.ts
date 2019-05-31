import { Component, OnInit } from '@angular/core';
import { AnimalsService, IAnimal, IFamily} from '../services/animals.service';
import { DataService } from '../services/data.service';

@Component({
  selector: 'app-create-animal',
  templateUrl: './create-animal.component.html',
  styleUrls: ['./create-animal.component.css']
})
export class CreateAnimalComponent implements OnInit {

  constructor(private svc: AnimalsService, private dataSvc: DataService) { }

  Animal: IAnimal;
  Family: IFamily;
  conservationStatus: string;
  description: string;
  imgurl: string;
  lifespan: number;
  name: string;
  order: string;
  familyName: string;
  ID: number;
  ngOnInit()
  {

  }
  UpdateAnimal()
  {

  }
  CreateAnimal() {
    this.Family = {
      name: this.familyName,
      description : ""
    }
    this.Animal = {

      name: this.name,
      description: this.description,
      conservationStatus: this.conservationStatus,
      order: this.order,
      imageURL: this.imgurl,
      lifeSpan: this.lifespan,
      family: this.Family

    }
    console.log(this.Animal.family.name)
    this.svc.PostAnimal(this.Animal).subscribe();

  }
}
