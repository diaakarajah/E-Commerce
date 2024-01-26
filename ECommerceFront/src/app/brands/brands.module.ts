import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { BrandsRoutingModule } from './brands-routing.module';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { BrandsService } from '../service/brands.service';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { FileUploadModule } from 'primeng/fileupload';

@NgModule({
  declarations: [ListComponent, CreateComponent],
  imports: [
    CommonModule,
    BrandsRoutingModule,
    FormsModule,
    TableModule,
    FileUploadModule
  ],
  providers: [BrandsService]
})
export class BrandsModule { }
