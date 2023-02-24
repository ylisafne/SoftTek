import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IVentas } from '../models/iventas';

@Injectable({
  providedIn: 'root'
})
export class VentasService {
  ListVenta: IVentas[];

  BaseUrl = 'http://localhost:32770/';
  apiUrl = 'ventas';
  constructor(private http: HttpClient) { }

  ListarVentas(){
    this.http.get(this.BaseUrl + this.apiUrl).toPromise().then(data=> {
      this.ListVenta = data as IVentas[];
    })
  }
  
}
