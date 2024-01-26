import { ResourceModel } from "../helper/resource-model";
import { BrandsDto } from "./brands-dto";
import { Category } from "./category";

export class ProductsDto extends ResourceModel<ProductsDto> {
  ProductNameAr!: string;
  ProductNameEn !: string;
  Description !: string;
  Price!: number;
  Quantity!: number;
  BrandId !: number;
  CategoryId!: number;
  brand!: BrandsDto;
  category!: Category;
}
