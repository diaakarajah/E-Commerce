import { Component, OnInit } from '@angular/core';
import { BrandsDto } from '../../Models/brands-dto';
import { BrandsService } from '../../service/brands.service';
import { HttpClient } from '@angular/common/http';
import { Location } from '@angular/common';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent implements OnInit {
  BrandsDto = new BrandsDto();
  file: any;
  myfile: any[] = [];
  maxFileSize = 10000000;
  contents: any = null;
  filename!: string;

  constructor(private brandService: BrandsService, private http: HttpClient, private location: Location) {

  }
  ngOnInit() {
    this.BrandsDto = new BrandsDto();
  }
  submit() {
    console.log(this.file);
    this.brandService.add(this.BrandsDto).subscribe(res => {
      this.UploadFile(res.id);
      this.clearData();
      this.location.back();
    });
  }

  onFileChanged(event: any) {
    this.file = event.target.files[0];
  }
  UploadFile(BrandId: any) {
    let filee: File = this.file;
    const formData: FormData = new FormData();
    formData.append('file', filee, filee.name);
    formData.append('fileType', '1');
    formData.append('RefId', BrandId);
    this.brandService.UploadFiles(formData).subscribe(res => { });
    }
  clearData() {
    this.BrandsDto = new BrandsDto();
  }
  Cancel() {
    this.location.back();
  }
  }

