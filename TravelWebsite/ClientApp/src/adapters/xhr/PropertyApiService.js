import Service from "./Service";

class PropertyApiService extends Service {
  constructor() {
    super("api");
  }

  getAll() {
    this.get(`/property`, (status, data) => {
      console.log(data);
    });
  }
}

export default new PropertyApiService();
