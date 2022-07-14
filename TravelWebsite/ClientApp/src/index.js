import { SnackbarProvider } from "notistack";
import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { LoadingIndicator } from "./components/loadingIndicator/LoadingIndicator";
import { AuthContextProvider } from "./contexts/AuthContext";
import { SearchContextProvider } from "./contexts/SearchContext";
import { SnackbarUtilsConfigurator } from "./SnackbarUtils";
const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <SnackbarProvider>
      <SnackbarUtilsConfigurator />
      <AuthContextProvider>
        <SearchContextProvider>
          <App />
          <LoadingIndicator />
        </SearchContextProvider>
      </AuthContextProvider>
    </SnackbarProvider>
  </React.StrictMode>
);
