import Api from "../Api/Api";

const url = "SimSizes";

export function getAllSimSizes() {
  return Api.get(url);
}

export function addSimSize(data) {
  return Api.post(url, data)
}

export function editSimSize(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteSimSize(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getSimSize(id) {
  return Api.get(url + "/" + id);
}


