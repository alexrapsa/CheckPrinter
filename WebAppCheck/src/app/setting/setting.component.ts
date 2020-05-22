import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-setting',
  templateUrl: './setting.component.html',
  styleUrls: ['./setting.component.css']
})
export class SettingComponent implements OnInit {
  isCollapsed = false;
  model: any = {};
  constructor() { }

  ngOnInit() {
  }

  submitSettings() {
    
  }

}
