import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TodoRepositoryService } from './todo-repository.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,
    HttpClientModule
  ],
  providers: [TodoRepositoryService],
  declarations: []
})
export class ServicesModule { }
