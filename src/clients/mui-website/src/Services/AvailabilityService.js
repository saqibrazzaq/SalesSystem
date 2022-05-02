import Api from "../Api/Api";

const url = "Availabilities";

export function getAllAvailabilities() {
  return Api.get(url);
}

export function addAvailability(data) {
  return Api.post(url, data)
}

export function editAvailability(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteAvailability(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getAvailability(id) {
  return Api.get(url + "/" + id);
}