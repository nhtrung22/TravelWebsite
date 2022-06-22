import Service from "./Service";

class AuthApiService extends Service {
  constructor() {
    super("api");
  }

  login(username, password, returnUrl) {
    this.post(
      `/authenticate`,
      {
        username: username,
        password: password,
      },
      (status, data) => {}
    );
  }
}

export default new AuthApiService();
