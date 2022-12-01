import { Entity } from "./entity";

export interface TipoImovel extends Entity {
  descricao: string;
  status: boolean;
}
