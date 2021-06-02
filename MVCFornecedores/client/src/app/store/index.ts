import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from "rxjs/operators";

@Injectable()
export class Store {

    constructor(private http: HttpClient) { }

    public empresas = [] as any;

    loadEmpresas() {
        return this.http.get<[]>("/api/empresa")
            .pipe(map(data => {
                this.empresas = data;
                return;
            }));
    }
}