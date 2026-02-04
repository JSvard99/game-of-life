import {Component, effect, inject} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Observable} from 'rxjs';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid {
  private http = inject(HttpClient);
  private API_URL = 'http://localhost:5081';
  private grid$!: Observable<Array<boolean>>;

  constructor() {
    effect(() => {
      this.grid$ = this.http.get<Array<boolean>>(`${this.API_URL}/grid`);
    });
  }
}
