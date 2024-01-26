import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutingModule } from './product-routing.module';
import { ListComponent } from './list/list.component';
import { CreateComponent } from './create/create.component';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { DropdownModule } from 'primeng/dropdown';
import { ProductService } from '../service/product.service';
import { CategoryService } from '../service/category.service';
import { BrandsService } from '../service/brands.service';


@NgModule({
  declarations: [ListComponent, CreateComponent],
  imports: [
    CommonModule,
    ProductRoutingModule,
    FormsModule,
    TableModule,
    DropdownModule,
  ],
  providers: [ProductService, CategoryService, BrandsService]
})
export class ProductModule { }
