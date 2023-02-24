import { HttpClient } from '@angular/common/http';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Route, Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Subscription } from 'rxjs';
import { IResponse } from 'src/app/models/iresponse';
import { IUser } from 'src/app/models/iuser';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit, OnDestroy {

  formLogin : FormGroup
  subRef$ : Subscription

  constructor(
    private fb : FormBuilder,
    private serv: LoginService,
    private route : Router,
    private cookServ : CookieService,
    private toast : ToastrService
  ){
    this.formLogin = this.fb.group({
      UserName: ['', Validators.required],
      Password: ['', Validators.required]
    })
  }
  Login(){
    const UsuarioLogin: IUser  ={
      UserName : this.formLogin.value.UserName,
      Password : this.formLogin.value.Password
    }
    this.subRef$ =  this.serv.IniciaSesion(UsuarioLogin).subscribe(res => {
      //sessionStorage.setItem("token", res.result!);
      if(res.success){
        this.cookServ.set("token", res.result!);
        this.route.navigate(["/home"]);
      }else{
        this.toast.error('Error', "Datos Incorrectos");
      }
      
    }, err => {console.log(err)})
    //this.subRef$ = this.http.post<IResponse>("http://localhost:32770/login", 
    //  UsuarioLogin, {observe : 'response'}).subscribe(res => {
    //    const token = res.body?.result!;
    //    console.log(res.body?.result);
    //    sessionStorage.setItem("token", token);
    //    this.route.navigate(["/home"]);}, err => {console.log("Error")}
    //    )
  }
  ngOnInit(): void {
    
  }
  ngOnDestroy(): void {
    if(this.subRef$){
      this.subRef$.unsubscribe();
    }
    
  }
  
 


}
