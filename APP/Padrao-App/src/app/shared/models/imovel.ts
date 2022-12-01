import { Categoria } from "./categoria";
import { Entity } from "./entity";
import { Foto } from "./foto";
import { TipoImovel } from "./tipo-imovel";


export interface Imovel extends Entity {
    nome: string;
    descricao: string;
    tipoImovel: TipoImovel;
    categoria: Categoria;
    fotos: Foto[];
}
