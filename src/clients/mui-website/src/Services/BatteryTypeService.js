import Api from "../Api/Api";

const url = "BatteryTypes";

export function getAllBatteryTypes() {
  return Api.get(url);
}

export function addBatteryType(data) {
  return Api.post(url, data)
}

export function editBatteryType(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteBatteryType(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getBatteryType(id) {
  return Api.get(url + "/" + id);
}