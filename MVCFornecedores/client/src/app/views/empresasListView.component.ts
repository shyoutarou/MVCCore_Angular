import { Component, OnInit } from "@angular/core";
import { Store } from '../store/index';

@Component({
  selector: "empresa-list",
  templateUrl: "empresasListView.component.html"
})
export class EmpresaListView implements OnInit {

    constructor(public store: Store) {
    }

    ngOnInit() {
        this.store.loadEmpresas()
            .subscribe();
    }
}
