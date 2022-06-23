import Service from "./Service";

class PropertyApiService extends Service {
  constructor() {
    super("api");
  }

  async getAll(params) {
    let result = await this.get(`/property`, params, (status, data) => {
      return data;
    });
    return result;
  }

  async getByCity(params) {
    let result = await this.get(`/property/GetByCity`, params, (status, data) => {
      return data;
    });
    return result;
  }

  async getByType(params) {
    let result = await this.get(`/property/GetByType`, params, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new PropertyApiService();
