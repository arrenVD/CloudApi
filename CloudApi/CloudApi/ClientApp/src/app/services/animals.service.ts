import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AnimalsService {

  constructor(private http: HttpClient) {

  }

  private Root_URL = "https://localhost:5001/api/v1/";
  public IMG_URL = "https://i.imgur.com/"
  public Animal: IAnimal;


  GetFamily(Name: string) {
    return this.http.get<IFamily>(`${this.Root_URL}families?name=${Name}`)
  }
  GetAnimalsList(Sort: string, Order: string, family: string, Page: Number, Length: Number, dir: string, ConversationStatus: string)
  {
    console.log(`${this.Root_URL}animals?family=${family}&length=${Length}&page=${Page}&sort=${Sort}&dir=${dir}&conservationstatus=${ConversationStatus}&order=${Order}`)
    return this.http.get<IRootObject>(`${this.Root_URL}animals?family=${family}&?length=${Length}&page=${Page}&sort=${Sort}&dir=${dir}&conservationstatus=${ConversationStatus}&order=${Order}`)
  }

  GetAnimal(id: number)
  {
    console.log(`${this.Root_URL}animals/${id}`)
    return this.http.get<IAnimal>(`${this.Root_URL}animals/${id}`)
  }
  PostAnimal(animal: IAnimal): Observable<IAnimal>{
    return this.http.post<IAnimal>(`${this.Root_URL}animals`, animal);
  }
}
  export interface IAnimal {
    id?: number;
    name: string;
    family: IFamily;
    description: string;
    lifeSpan: number;
    conservationStatus: string;
    imageURL: string;
    familyId?: number;
    order: string;
}
export interface IFamily {
  name: string;
  description?: string;
}
export interface IRootObject {
  amountOfAnimals: number;
  animal: IAnimal[];
  AmountOfPages: number;
}


export interface IFamilyList {
  family: IFamily[];
}

