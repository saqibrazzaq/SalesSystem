import Api from "../Api/Api";

const url = "Wifis";

export function getWifis() {
  return Api.get(url);
}

export function addWifi(data) {
  return Api.post(url, data)
}

export function editWifi(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteWifi(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getWifi(id) {
  return Api.get(url + "/" + id);
}