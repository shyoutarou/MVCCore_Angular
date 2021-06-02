import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { EmpresaListView } from './views/empresasListView.component';
import { Store } from './store/index';

@NgModule({
  declarations: [
        AppComponent,
        EmpresaListView
  ],
  imports: [
      BrowserModule,
      HttpClientModule 
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }
