import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiHelper } from '../helper/api-route';
import { ProductsDto } from '../Models/products-dto';
import { ResourceService } from '../helper/resource-service';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends ResourceService<ProductsDto> {
  apiHelper!: apiHelper;

  constructor(private http: HttpClient) {
    super(
      http,
      ProductsDto,
      apiHelper.productApi
    );
  }
  add(create: ProductsDto) {
    return this.create(create);
  }
  getall(filter: any) {
    return this.get(filter);
  }
  UploadFiles(form: any) {
    return this.UploadFile(form);
  }
}
