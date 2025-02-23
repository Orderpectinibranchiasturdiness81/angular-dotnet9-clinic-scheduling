export class UserProfileModel {
  Id?: number;
  nameAr!: string;
  nameEn!: string;
  description?: string;
  phoneNumber!: string;
}


export class UserProfileFilter {
  name?: string = undefined;
  phoneNumber?: string = undefined;
}
