import Api from "../Api/Api";

const url = "FormFactors";

export function getAllFormFactors() {
  return Api.get(url);
}

export function addFormFactor(data) {
  return Api.post(url, data)
}

export function editFormFactor(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteFormFactor(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getFormFactor(id) {
  return Api.get(url + "/" + id);
}


