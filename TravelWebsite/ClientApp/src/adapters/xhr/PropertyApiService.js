import Service from "./Service";

class PropertyApiService extends Service {
  constructor() {
    super("api");
  }

  async getAll(params) {
    let result = this.get(`/property`, params, (status, data) => {
      return data;
    });
    return result;
  }

  async getByCity(params) {
    let result = this.get(`/property/GetByCity`, params, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new PropertyApiService();
