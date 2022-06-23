import { setCookie } from "../../Utils";
import Service from "./Service";

class AuthApiService extends Service {
  constructor() {
    super("api");
  }

  async login(username, password, returnUrl) {
    let result = await this.post(`/authenticate`, { username: username, password: password }, (status, data) => {
      return data;
    });
    setCookie("jwtToken", result.jwtToken);
    return result;
  }
}

export default new AuthApiService();
