import { setCookie } from "../../Utils";
import Service from "./Service";

class AdminApiService extends Service {
  constructor() {
    super("api");
  }

  async getStatistics() {
    let result = await this.get(`/admin/statistics`, {}, (status, data) => {
      return data;
    });
    return result;
  }
}

export default new AdminApiService();
