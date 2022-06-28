import Service from "./Service";

class BookingApiService extends Service {
  constructor() {
    super("api");
  }

  async add(payload) {
    let result = await this.post(`/booking`, payload, (status, data) => {
      return data;
    });
    return result;
  }

  async getAll(params) {
    let result = await this.get(`/booking`, params, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new BookingApiService();
