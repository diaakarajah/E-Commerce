import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../service/product.service';
import { ProductsDto } from '../../Models/products-dto';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrl: './list.component.css'
})
export class ListComponent implements OnInit {
  productList: ProductsDto[] = [];
  constructor(private productService: ProductService) {

  }
  ngOnInit() {
    this.getAll();
  }
  getAll() {
    this.productService.getall(null).subscribe(res => {
      this.productList = res;
      console.log(res)
    })

  }
  createImgPath(serverPath: string) {
    return `https://localhost:5001/${serverPath}`;
  }
}
