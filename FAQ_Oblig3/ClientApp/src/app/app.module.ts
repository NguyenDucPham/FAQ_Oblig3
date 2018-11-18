import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { hoved } from './hoved';
@NgModule({
  imports: [BrowserModule, ReactiveFormsModule, HttpModule, JsonpModule],
  declarations: [hoved],
  bootstrap: [hoved]
})
export class AppModule { }
