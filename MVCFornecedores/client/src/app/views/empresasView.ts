import { Component, OnInit } from "@angular/core";
import { Store } from '../store/index';

@Component({
    selector: "empresa-list",
    templateUrl: "empresasView.html",
    styleUrls: [ "empresasView.css" ]
})
export class EmpresaView implements OnInit {

    constructor(public store: Store) {
    }

    ngOnInit() {
        this.store.loadEmpresas()
            .subscribe();
    }
}
