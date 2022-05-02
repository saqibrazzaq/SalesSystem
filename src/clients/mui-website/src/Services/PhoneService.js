import Api from "../Api/Api";

export function getAllPhones() {
  return Api.get('/phones');
}
