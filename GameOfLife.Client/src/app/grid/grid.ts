import {Component, inject} from '@angular/core';
import {Grid as GridService} from '../grid';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid {
  gridService = inject(GridService);

  protected switchCellState(rowIndex: number, columnIndex: number) {
    this.gridService.switchCellState(rowIndex, columnIndex);
  }
}
