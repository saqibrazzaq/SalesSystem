import Api from "../Api/Api";

export function getAllBrands() {
  return Api.get('/brands')
}

