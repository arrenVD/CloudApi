import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { MoviesService } from '../services/movies.service';
import { AnimalsService, IAnimal } from '../services/animals.service';

@Component({
  selector: 'app-animal',
  templateUrl: './animal.component.html',
  styleUrls: ['./animal.component.css']
})
export class AnimalComponent implements OnInit {

  constructor(private router: Router, private svc: AnimalsService, private activatedRoute: ActivatedRoute) {

    this.url_imgRoot = this.svc.IMG_URL
    this.activatedRoute.params.subscribe(params => {
      if (typeof params['id'] !== 'undefined') {
        this.ID = params['id'];
      } else {
        this.ID = 2;
      }
    })
    this.svc.GetAnimal(this.ID).subscribe((result => {
      this.Animal = result
      console.log(this.Animal)
    }))




  }
  url: string;
  url_imgRoot: string;
  ID: number
  Animal: IAnimal;
  ngOnInit() {


  }

}
