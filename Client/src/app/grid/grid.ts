import {Component, inject, signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid {
  private http = inject(HttpClient);
  private API_URL = 'http://localhost:5081';
  grid = signal<boolean[][]>([]);

  constructor() {
    this.http.get<Array<Array<boolean>>>(`${this.API_URL}/grid`).subscribe((response) => {
      this.grid.set(response);
    });
  }
}
