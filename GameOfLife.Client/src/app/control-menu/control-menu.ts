import {Component, inject} from '@angular/core';
import {Grid as GridService} from '../grid';

@Component({
  selector: 'app-control-menu',
  imports: [],
  templateUrl: './control-menu.html',
  styleUrl: './control-menu.scss',
})
export class ControlMenu {
  gridService = inject(GridService);

  protected clearGrid(): void {
    this.gridService.clearGrid();
  }

  protected randomizeGrid(): void {
    this.gridService.randomizeGrid();
  }

  protected updateGrid(): void {
    this.gridService.updateGrid();
  }

  protected toggleAutoUpdate(): void {
    this.gridService.toggleAutoUpdate();
  }
}
