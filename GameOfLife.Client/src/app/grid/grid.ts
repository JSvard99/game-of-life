import {Component, inject, signal, OnInit} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid implements OnInit {
  private http = inject(HttpClient);
  private API_URL = 'http://localhost:5081';
  grid = signal<boolean[][]>([]);

  ngOnInit() {
    this.http.get<Array<Array<boolean>>>(`${this.API_URL}/grid`).subscribe((response) => {
      this.grid.set(response);
    });
  }

  switchCellState(row: number, column: number): void {
    let newState = !this.grid()[row][column];

    this.http.put<boolean[][]>(`${this.API_URL}/grid/${row}/${column}`, {
      state: newState
    }).subscribe((response) => {
      this.grid.set(response);
    })
  }

}
