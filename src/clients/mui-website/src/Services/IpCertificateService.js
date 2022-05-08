import Api from "../Api/Api";

const url = "IpCertificates";

export function getAllIpCertificate() {
  return Api.get(url);
}

export function addIpCertificate(data) {
  return Api.post(url, data)
}

export function editIpCertificate(data) {
  return Api.put(url, data, {
    params: {
      id: data.id
    }
  })
}

export function deleteIpCertificate(id) {
  return Api.delete(url, {
    params: {
      id: id
    }
  })
}

export function getIpCertificate(id) {
  return Api.get(url + "/" + id);
}


