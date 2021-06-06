import { Component, OnInit } from "@angular/core";
import { Store } from '../store/index';

@Component({
    selector: "fornecedores",
    templateUrl: "fornecedorView.html",
    styleUrls: ["fornecedorView.css"]
})
export class FornecedorView implements OnInit {

    constructor(public store: Store) {
    }

    ngOnInit() {
        this.store.loadEmpresas()
            .subscribe();
    }
}
