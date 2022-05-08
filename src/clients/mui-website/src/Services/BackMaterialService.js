import Api from "../Api/Api";

const url = "BackMaterials";

export function getAllBackMaterials() {
  return Api.get(url);
}

export function addBackMaterial(data) {
  return Api.post(url, data)
}

export function editBackMaterial(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteBackMaterial(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getBackMaterial(id) {
  return Api.get(url + "/" + id);
}


