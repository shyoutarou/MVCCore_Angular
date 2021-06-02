﻿import { Contato } from './contato';

export class Fornecedor {
    id: number = 0;
    nome: string = "";
    cpF_CNPJ: string = "";
    rg: string = "";
    dataCadastro?: Date;
    dataNascimento?: Date;
    contatos?: Contato[] = new Array<Contato>();
}