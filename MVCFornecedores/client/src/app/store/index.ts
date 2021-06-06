import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";
import { Empresa } from '../model/empresa';
import { Fornecedor } from '../model/fornecedor';

@Injectable()
export class Store {

    constructor(private http: HttpClient) { }

    fornecedor = new Fornecedor();
    empresas = [] as any;
    fornecedores = new Array<Fornecedor>();
    errorMessage = "";

    loadEmpresas() {
        return this.http.get<Observable<Empresa[]>>("/api/empresa")
            .pipe(map(data => this.empresas = data));
    }

    addToEmpresa(id: number = 0) {
        let empresa = this.empresas[0];

        this.fornecedor.id = id;
        this.fornecedor.nome = "Ruy " + id;
        this.fornecedor.rg = id.toString() + id + id;
        this.fornecedores.push(this.fornecedor);
    }

    clearOrder() {
        this.empresas = [] as any;
    }

    checkout() {

        //const headers = new HttpHeaders().set("Authorization", "Bearer " + this.token);

        //return this.http.post("/api/orders", this.order, {
        //    headers: headers
        //});

    }
}