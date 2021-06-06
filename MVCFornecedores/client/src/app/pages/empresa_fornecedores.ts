import { Component, OnInit } from "@angular/core";
import { Store } from '../store/index';

@Component({
  selector: "empresa-fornecedores",
    templateUrl: "empresa_fornecedores.html"
})
export default class EmpresaFornecedoresPage implements OnInit {

    title = 'EmpresaFornecedoresPage';

    constructor(public store: Store) {
    }

    ngOnInit() {
        this.store.loadEmpresas()
            .subscribe();
    }
}
