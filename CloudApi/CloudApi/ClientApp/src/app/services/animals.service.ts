import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class AnimalsService {

  constructor(private http: HttpClient) {

  }

   private Root_URL = "https://localhost:5001/api/v1/";

  GetAnimalsList(Sort: string, Order: string, Page: Number, Length: Number, dir: string, ConversationStatus: string) {

    return this.http.get<RootObject>(`${this.Root_URL}/animals?length=${length}&sort=${Sort}&dir=${dir}&conservationstatus=${ConversationStatus}&Order=${Order}`)
  }
}
  export interface RootObject {
    id: number;
    name: string;
    family?: Family;
    description: string;
    lifeSpan: number;
    conservationStatus: string;
    imageURL: string;
    familyId: number;
    order: string;
}
export interface Family {
  id: number;
  name: string;
  description: string;
}

