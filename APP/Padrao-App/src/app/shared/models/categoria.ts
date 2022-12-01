import { Entity } from "./entity";

export interface Categoria extends Entity {
  nome: string;
  status: boolean;
}
