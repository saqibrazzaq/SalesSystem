import Api from "../Api/Api";

const url = "FrameMaterials";

export function getAllFrameMaterials() {
  return Api.get(url);
}

export function addFrameMaterial(data) {
  return Api.post(url, data)
}

export function editFrameMaterial(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteFrameMaterial(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getFrameMaterial(id) {
  return Api.get(url + "/" + id);
}


