import { Injectable } from '@angular/core';
import { apiHelper } from '../helper/api-route';
import { ResourceService } from '../helper/resource-service';
import { Category } from '../Models/category';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CategoryService extends ResourceService<Category> {
  apiHelper!: apiHelper;

  constructor(private http: HttpClient) {
    super(
      http,
      Category,
      apiHelper.cateoryApi
    );
  }
  add(create: Category) {
    return this.create(create);
  }
  getall(filter: any) {
    return this.get(filter);
  }
  UploadFiles(form: any) {
    return this.UploadFile(form);
  }
}
