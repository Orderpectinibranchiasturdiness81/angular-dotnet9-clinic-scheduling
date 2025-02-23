import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-pagination',
  standalone: false,
  
  templateUrl: './pagination.component.html',
  styleUrl: './pagination.component.css'
})
export class PaginationComponent implements OnInit {

  @Input() totalCount: number = 0;
  @Input() pageIndex: number = 0;
  @Input() pageSize: number = 10;
  @Output() pageChange = new EventEmitter<number>();
  //------------------**
  pages: number[] = [];
  totalPagesCount: number = 0;
  //---------------------------------------------------------**
  constructor() { }

  ngOnInit(): void { }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['totalCount']?.currentValue) {
      this.totalCount = changes['totalCount'].currentValue;
    }

    if (changes['pageIndex']?.currentValue) {
      this.pageIndex = changes['pageIndex'].currentValue;
    }

    if (changes['pageSize']?.currentValue) {
      this.pageSize = changes['pageSize'].currentValue;
    }
    this.updatePagination();
  }

  private updatePagination(): void {
    this.totalPagesCount = Math.ceil(this.totalCount / this.pageSize);
    this.pages = Array.from({ length: this.totalPagesCount }, (_, index) => index);
  }

  goToPage(page: number): void {
    if (page >= 0 && page < this.totalPagesCount) {
      this.pageChange.emit(page);
    }
  }
}
