import { Component, inject } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid {
  private http = inject(HttpClient);
}
