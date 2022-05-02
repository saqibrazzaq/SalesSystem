import Api from "../Api/Api";

const url = "/brands";

export function getAllBrands() {
  return Api.get(url)
}

export function addBrand(data) {
  return Api.post(url, data);
}

export function editBrand(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  });
}

export function deleteBrand(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  });
}

export function getBrand(id) {
  return Api.get(`${url}/${id}`);
}
