import { ResourceModel } from "../helper/resource-model";

export class BrandsDto extends ResourceModel<BrandsDto> {
  brandNameAr!: string;
  brandNameEn!: string;
  Image!: string;
}
