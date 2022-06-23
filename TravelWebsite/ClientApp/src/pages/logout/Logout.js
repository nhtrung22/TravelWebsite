import { Box, Grid } from "@mui/material";
import React, { useContext, useEffect } from "react";
import { AuthContext } from "../../contexts/AuthContext";

function navigateToReturnUrl(returnUrl) {
  // It's important that we do a replace here so that we remove the callback uri with the
  // fragment containing the tokens from the browser history.
  // window.history.pushState(null, null, returnUrl);
  window.location.replace(returnUrl);
}

export const Logout = (props) => {
  const { loading, error, dispatch } = useContext(AuthContext);
  const logout = () => {
    dispatch({ type: "LOGOUT" });
    window.location.replace("/");
  };

  useEffect(() => {
    logout();
  }, []);

  return (
    <Box>
      <Grid container justifyContent="center">
        <Grid item>
          <h1>{"Processing logout"}</h1>
        </Grid>
      </Grid>
    </Box>
  );
};
