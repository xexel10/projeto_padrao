import { Imovel } from './imovel';
import { Entity } from "./entity";

export interface Foto extends Entity {
    descricao: string;
    imagemUrl: string;
    imovel: Imovel;
}
