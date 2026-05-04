import {inject, Injectable, signal} from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class Grid {
  private http = inject(HttpClient);
  private API_URL = 'http://localhost:5081';
  grid = signal<boolean[][]>([]);
  autoUpdateDelay = 250;
  isPlaying = false;
  intervalId: number = -1;

  constructor() {
    this.http.get<Array<Array<boolean>>>(`${this.API_URL}/grid`).subscribe((response) => {
      this.grid.set(response);
    });
  }

  switchCellState(row: number, column: number): void {
    if (this.isPlaying) {
      return;
    }

    let newState = !this.grid()[row][column];

    this.http.put<boolean[][]>(`${this.API_URL}/grid/${row}/${column}`, {}, {
      params: { state: newState },
    }).subscribe((response) => {
      this.grid.set(response);
    })
  }

  updateGrid(): void {
    this.http.post<boolean[][]>(`${this.API_URL}/grid/update`, null)
      .subscribe((response) => {
        this.grid.set(response);
      })
  }

  clearGrid(): void {
    this.http.post<boolean[][]>(`${this.API_URL}/grid/clear`, null)
      .subscribe((response) => {
        this.grid.set(response);
      })
  }

  toggleAutoUpdate(): void {
    if (!this.isPlaying) {
      this.intervalId = setInterval(() => {this.updateGrid()}, this.autoUpdateDelay);
    }
    else {
      clearInterval(this.intervalId);
    }

    this.isPlaying = !this.isPlaying;
  }
}
