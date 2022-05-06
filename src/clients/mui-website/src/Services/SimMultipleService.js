import Api from "../Api/Api";

const url = "SimMultiples";

export function getAllSimMultiples() {
  return Api.get(url);
}

export function addSimMultiple(data) {
  return Api.post(url, data)
}

export function editSimMultiple(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteSimMultiple(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getSimMultiple(id) {
  return Api.get(url + "/" + id);
}


