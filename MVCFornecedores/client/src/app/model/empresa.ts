import { Fornecedor } from './fornecedor';

export class Empresa {
    id: number = 0;
    uf: string = "";
    nomeFantasia: string = "";
    cnpj: string = "";
    fornecedores?: Fornecedor[] = new Array<Fornecedor>();
}