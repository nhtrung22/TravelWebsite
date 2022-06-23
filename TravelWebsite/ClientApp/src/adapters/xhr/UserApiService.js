import Service from "./Service";

class UserApiService extends Service {
  constructor() {
    super("api");
  }

  async getAll(params) {
    let result = await this.get(`/user`, params, (status, data) => {
      return data;
    });
    return result;
  }

  async create(payload) {
    let result = await this.post(`/User/register`, payload, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new UserApiService();
