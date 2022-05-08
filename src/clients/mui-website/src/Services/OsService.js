import Api from "../Api/Api";

const url = "OSes";

export function getAllOSes() {
  return Api.get(url);
}

export function addOS(data) {
  return Api.post(url, data)
}

export function editOS(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteOS(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getOS(id) {
  return Api.get(url + "/" + id);
}