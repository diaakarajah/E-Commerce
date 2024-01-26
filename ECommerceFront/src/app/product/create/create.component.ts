import { Component, OnInit } from '@angular/core';
import { ProductsDto } from '../../Models/products-dto';
import { SelectItem } from 'primeng/api';
import { BrandsService } from '../../service/brands.service';
import { CategoryService } from '../../service/category.service';
import { ProductService } from '../../service/product.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent implements OnInit {
  product = new ProductsDto();
  brandItems: SelectItem[] = [];
  categoryItems: SelectItem[] = [];
  file: any;
  constructor(private brandService: BrandsService, private categoryService: CategoryService, private productService: ProductService, private location: Location) {

  }
  ngOnInit() {
    this.getAllBrands();
    this.getAllCategory();
  }
  getAllBrands() {
    this.brandService.getall(null).subscribe(res => {
      if (res.length > 0) {
        for (let i = 0; i < res.length; i++) {
          this.brandItems.push({ label: res[i].brandNameEn, value: res[i].id });
        }
      }
    })
  }
  getAllCategory() {
    this.categoryItems = [];
    this.categoryService.getall(null).subscribe(res => {
      console.log(res);
      if (res != null) {
        for (let i = 0; i < res.length; i++) {
          this.categoryItems.push({ label: res[i].categoryNameEn, value: res[i].id });
        }
      }
    })
  }
  submit() {
    this.productService.add(this.product).subscribe(res => {
      if (res.id != null && res.id > 0) {
        this.UploadFile(res.id);
        this.clearData();
        this.location.back(); // <-- go back to previous location on cancel

      }
    })
  }
  onFileChanged(event: any) {
    this.file = event.target.files[0];
  }
  UploadFile(ProductId: any) {
    let filee: File = this.file;
    const formData: FormData = new FormData();
    formData.append('file', filee, filee.name);
    formData.append('fileType', '1');
    formData.append('RefId', ProductId);
    this.productService.UploadFiles(formData).subscribe(res => { });
  }
  //onChange($event: any) {
  //  this.product.CategoryId = $event.value;
  //}
  //onChangeBrand($event: any) {
  //  this.product.BrandId = $event.value;
  //}
  clearData() {
    this.product = new ProductsDto();
  }
  Cancel() {
    this.location.back();
  }
}
