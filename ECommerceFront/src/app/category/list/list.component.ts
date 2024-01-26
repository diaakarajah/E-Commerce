import { Component, OnInit } from '@angular/core';
import { Category } from '../../Models/category';
import { CategoryService } from '../../service/category.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  categoryList: Category[] = [];
  filter: any;
  constructor(private categoryService: CategoryService) {

  }
  ngOnInit() {
    this.getAll();
  }
  getAll() {
    this.categoryService.getall(this.filter).subscribe(res => {
      this.categoryList = res;
    })
  }
  createImgPath(serverPath: string) {
    return `https://localhost:5001/${serverPath}`;
  }
}
