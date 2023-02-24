import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class JwtInterceptorInterceptor implements HttpInterceptor {

  constructor(
    private cookieServ: CookieService

  ) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    const token = this.cookieServ.get("token");
    request = request.clone({
      //setHeaders :{Authorization : 'Bearer ${token}'}
      headers: request.headers.append("Authorization", "Bearer " + token)
    });
    return next.handle(request);
  }
}
