import {Component, inject} from '@angular/core';
import {Grid as GridService} from '../grid';
import {Coordinate} from '../coordinate';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
})
export class Grid {
  gridService = inject(GridService);
  isDrawing: boolean = false;

  protected switchCellState(row: number, column: number) {

    const coordinate: Coordinate = {
      row,
      column
    };

    this.gridService.switchCellState(coordinate);
  }

  protected onMouseDownCell() {
    this.isDrawing = true;
  }

  protected onMouseEnterCell(row: number, column: number) {
    if (this.isDrawing) {
      console.log('onHoverCell', row, column);
    }
  }
}
