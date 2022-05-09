import Api from "../Api/Api";

const url = "CameraTypes";

export function getAllCameraTypes() {
  return Api.get(url);
}

export function addCameraType(data) {
  return Api.post(url, data)
}

export function editCameraType(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteCameraType(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getCameraType(id) {
  return Api.get(url + "/" + id);
}