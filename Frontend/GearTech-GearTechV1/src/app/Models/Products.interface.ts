export class ListProductsI{
    idProduct: number;
    productName: string;
    productPrice : number;
    productStock : number;
    imageProduct : string;
    idCategory : number;
    category:[categoryName: string]
            
    
    //token: string;
}
export interface ProductsI{
    idProduct: number;
    productName: string;
    productPrice : number;
    productStock : number;
    imageProduct : string;
    idCategory : number;
    //token: string;
}
export class ProductsC{
    idProduct: number;
    productName: string;
    productPrice : number;
    productStock : number;
    imageProduct : string;
    idCategory : number;
    //token: string;
}