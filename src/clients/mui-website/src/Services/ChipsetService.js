import Api from "../Api/Api";

const url = "Chipsets";

export function getAllChipsets() {
  return Api.get(url);
}

export function addChipset(data) {
  return Api.post(url, data)
}

export function editChipset(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteChipset(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getChipset(id) {
  return Api.get(url + "/" + id);
}