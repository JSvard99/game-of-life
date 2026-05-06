import {Component, HostListener, inject} from '@angular/core';
import {Grid as GridService} from '../grid';
import {Coordinate} from '../coordinate';

@Component({
  selector: 'app-grid',
  imports: [],
  templateUrl: './grid.html',
  styleUrl: './grid.scss',
  host: {
    '(window:mouseup)': 'onMouseUp()',
  }
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

  onMouseUp() {
    this.isDrawing = false;
  }

  protected onMouseEnterCell(row: number, column: number) {
    if (this.isDrawing) {
      let coordinate: Coordinate = {
        row,
        column
      }

      this.gridService.switchCellState(coordinate);
    }
  }
}
