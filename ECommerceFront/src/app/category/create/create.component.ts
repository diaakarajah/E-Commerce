import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../service/category.service';
import { Category } from '../../Models/category';
import { Location } from '@angular/common';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrl: './create.component.css'
})
export class CreateComponent implements OnInit {
  category = new Category();
  file: any;

  constructor(private categoryService: CategoryService, private location: Location) {

  }
  ngOnInit() {

  }
  submit() {
    this.categoryService.add(this.category).subscribe(res => {
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
    this.categoryService.UploadFiles(formData).subscribe(res => {
    });
  }
  clearData() {
    this.category = new Category();
  }
  Cancel() {
    this.location.back();
  }
}

