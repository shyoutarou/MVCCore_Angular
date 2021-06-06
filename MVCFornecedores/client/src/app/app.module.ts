import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { EmpresaView } from './views/empresasView';
import { FornecedorView } from './views/fornecedorView';
import { Store } from './store/index';

@NgModule({
  declarations: [
        AppComponent,
        EmpresaView,
        FornecedorView
  ],
  imports: [
      BrowserModule,
      HttpClientModule 
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }
