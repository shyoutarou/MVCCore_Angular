import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { EmpresaView } from './views/empresasView';
import { FornecedorView } from './views/fornecedorView';
import { Store } from './store/index';
import router from './services/router';
import EmpresaFornecedoresPage from './pages/empresa_fornecedores';
import CheckoutPage from './pages/CheckoutPage';

@NgModule({
  declarations: [
        AppComponent,
        EmpresaView,
        FornecedorView,
        EmpresaFornecedoresPage,
        CheckoutPage
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router
  ],
  providers: [Store],
  bootstrap: [AppComponent]
})
export class AppModule { }
