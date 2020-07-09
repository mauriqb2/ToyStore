import { Toy } from '../models/toy';

export class Enterprise {
    id?:number;
    name:string;
    country: string;
    description: string;
    toys: Toy[]
  } 