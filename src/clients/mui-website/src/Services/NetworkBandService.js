import Api from "../Api/Api";

const url = "NetworkBands";

export function getAllBands(networkId) {
  return Api.get(url, {
    params: {
      networkId: networkId
    }
  });
}

export function addBand(data) {
  return Api.post(url, data)
}

export function editBand(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteBand(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getBand(id) {
  return Api.get(url + "/" + id);
}

