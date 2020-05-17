import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-check',
  templateUrl: './check.component.html',
  styleUrls: ['./check.component.css']
})
export class CheckComponent implements OnInit {

  checks: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getChecks();
  }

  getChecks(){
    this.http.get('http://localhost:5000/api/check').subscribe(response => {
      this.checks = response;
    }, error => {
      console.log(error);
    })
  }

}
