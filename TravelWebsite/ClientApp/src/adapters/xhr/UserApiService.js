import Service from "./Service";

class UserApiService extends Service {
  constructor() {
    super("api");
  }

  async getAll(params) {
    let result = this.get(`/user`, params, (status, data) => {
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

  async getByType(params) {
    let result = this.get(`/property/GetByType`, params, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new UserApiService();
