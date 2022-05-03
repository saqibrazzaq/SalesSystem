import Api from "../Api/Api";

const url = "NetworkBands";

export function getAllBands(networkId) {
  return Api.get(url, {
    params: {
      networkId: networkId
    }
  });
}

