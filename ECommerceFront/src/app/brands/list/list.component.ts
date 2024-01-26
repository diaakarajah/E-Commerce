import { Component, OnInit } from '@angular/core';
import { BrandsService } from '../../service/brands.service';
import { BrandsDto } from '../../Models/brands-dto';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  filter: any;
  brandList: BrandsDto[] = [];


  constructor(private brandService: BrandsService) {
    this.getAll();

  }
  ngOnInit() {
  }
  getAll() {
    this.brandService.getall(this.filter).subscribe(res => {
      this.brandList = res;
      console.log(this.brandList);
    })
  }
   createImgPath (serverPath: string) {
    return `https://localhost:5001/${serverPath}`;
  }
}
