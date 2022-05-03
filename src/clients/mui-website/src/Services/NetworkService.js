import Api from "../Api/Api";

const url = "Networks";

export function getAllNetworks() {
  return Api.get(url);
}

export function addNetwork(data) {
  return Api.post(url, data)
}

export function editNetwork(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteNetwork(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getNetwork(id) {
  return Api.get(url + "/" + id);
}
