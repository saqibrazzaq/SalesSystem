import Api from "../Api/Api";

const url = "Bluetooths";

export function getAllBluetooths() {
  return Api.get(url);
}

export function addBluetooth(data) {
  return Api.post(url, data)
}

export function editBluetooth(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteBluetooth(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getBluetooth(id) {
  return Api.get(url + "/" + id);
}