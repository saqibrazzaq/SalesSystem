import Api from "../Api/Api";

export function getAllBrands() {
  return Api.get('/brands')
}

export function addBrand(brand) {
  return Api.post("/brands", brand);
}

export function editBrand(brand) {
  return Api.put("/brands", brand, {
    params: {
      id: brand.id
    }
  });
}

export function deleteBrand(id) {
  return Api.delete("/brands", {
    params: {
      id: id
    }
  });
}

export function getBrand(id) {
  return Api.get(`/brands/${id}`);
}
