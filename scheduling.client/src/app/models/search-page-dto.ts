export class SearchPageDto<T> {
  page: number = 1;
  pageIndex: number = 0;
  pageSize: number = 10;
  criteria!: T;
}
