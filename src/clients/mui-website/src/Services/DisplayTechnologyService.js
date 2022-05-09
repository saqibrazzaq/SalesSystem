import Api from "../Api/Api";

const url = "DisplayTechnologies";

export function getAllDisplayTechnologies() {
  return Api.get(url);
}

export function addDisplayTechnology(data) {
  return Api.post(url, data)
}

export function editDisplayTechnology(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteDisplayTechnology(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getDisplayTechnology(id) {
  return Api.get(url + "/" + id);
}