import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule }   from '@angular/forms';

import { AppComponent } from './app.component';
import { CounterComponent } from './counter/counter.component';
import { TodoListComponent } from './todo-list/todo-list.component';
import { ServicesModule } from './services/services.module';
import { TodoDetailComponent } from './todo-detail/todo-detail.component';
import { OAuthModule } from 'angular-oauth2-oidc';
import { LoginStatusComponent } from './login-status/login-status.component';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptorService } from './auth-interceptor.service';


@NgModule({
  declarations: [
    AppComponent,
    CounterComponent,
    TodoListComponent,
    TodoDetailComponent,
    LoginStatusComponent
  ],
  imports: [
    OAuthModule.forRoot(),
    BrowserModule,
    ServicesModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: CounterComponent, pathMatch: 'full' },
      { path: 'todos/:id', component: TodoDetailComponent },
      { path: 'todos', component: TodoListComponent }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
