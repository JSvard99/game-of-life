import { Component } from '@angular/core';
import {Grid} from '../grid/grid';
import {ControlMenu} from '../control-menu/control-menu';

@Component({
  selector: 'app-main-page',
  imports: [
    Grid,
    ControlMenu
  ],
  templateUrl: './main-page.html',
  styleUrl: './main-page.scss',
})
export class MainPage {

}
