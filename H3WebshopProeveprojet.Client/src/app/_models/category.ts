import { Product } from "./product";

export interface Category {
    id: number;
    categoryName: string;
    products?: Product[];
}