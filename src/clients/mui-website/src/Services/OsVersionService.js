import Api from "../Api/Api";

const url = "OSVersions";

export function getAllOSVersions(data) {
  return Api.post(url + "/GetAllByOS", data);
}

export function addOSVersion(data) {
  return Api.post(url, data)
}

export function editOSVersion(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteOSVersion(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getOSVersion(id) {
  return Api.get(url + "/" + id);
}