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
  drawingState: boolean = false;

  protected switchCellState(row: number, column: number, event: MouseEvent) {
    // Disables the drag event which might mess with the drawing
    event.preventDefault()

    const coordinate: Coordinate = {
      row,
      column
    };

    this.gridService.switchCellState(coordinate);

    this.isDrawing = true;
    this.drawingState = !this.gridService.grid()[row][column];
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

      if (this.gridService.grid()[row][column] !== this.drawingState) {
        this.gridService.switchCellState(coordinate);
      }
    }
  }
}
