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
  autoUpdateDelay = 250;
  isPlaying = false;
  intervalId: number = -1;

  protected updateGrid(): void {
    this.gridService.updateGrid();
  }

  protected toggleAutoUpdate(): void {
    if (!this.isPlaying) {
      this.intervalId = setInterval(() => {this.updateGrid()}, this.autoUpdateDelay);
    }
    else {
      clearInterval(this.intervalId);
    }

    this.isPlaying = !this.isPlaying;
  }
}
