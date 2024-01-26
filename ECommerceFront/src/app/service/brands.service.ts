import { Injectable } from '@angular/core';
import { ResourceService } from '../helper/resource-service';
import { BrandsDto } from '../Models/brands-dto';
import { apiHelper } from '../helper/api-route';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BrandsService extends ResourceService<BrandsDto> {
  apiHelper!: apiHelper;

  constructor(private http: HttpClient) {
    super(
      http,
      BrandsDto,
      apiHelper.brandsApi
    );
  }
  add(create: BrandsDto) {
    return this.create(create);
  }
  getall(filter: any) {
    return this.get(filter);
  }
  UploadFiles(form: any) {
    return this.UploadFile(form);
  }
}
