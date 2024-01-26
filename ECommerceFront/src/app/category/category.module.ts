import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CategoryRoutingModule } from './category-routing.module';
import { CreateComponent } from './create/create.component';
import { ListComponent } from './list/list.component';
import { FormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { CategoryService } from '../service/category.service';


@NgModule({
  declarations: [CreateComponent, ListComponent],
  imports: [
    CommonModule,
    CategoryRoutingModule,
    FormsModule,
    TableModule
  ],
  providers: [CategoryService]
})
export class CategoryModule { }
