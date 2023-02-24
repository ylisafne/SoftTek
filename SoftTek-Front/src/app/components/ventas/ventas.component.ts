import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { VentasService } from 'src/app/Services/ventas.service';

@Component({
  selector: 'app-ventas',
  templateUrl: './ventas.component.html',
  styleUrls: ['./ventas.component.css']
})
export class VentasComponent implements OnInit {
  constructor(public serv : VentasService,
    private toast: ToastrService) { }

  ngOnInit(): void {
    this.serv.ListarVentas();
  }


}
