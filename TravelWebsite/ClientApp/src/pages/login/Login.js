import { Alert, Box, Grid, Link } from "@mui/material";
import React, { useCallback, useContext, useState } from "react";
import { useNavigate } from "react-router-dom";
import { MyButton } from "../../components/myButton/MyButton";
import { MyTextField } from "../../components/myTextField/MyTextField";
import { QueryParameterNames, ValidTextRegExp } from "../../Constant";
import MyContext from "../../contexts/MyContext";
import Navbar from "../../components/navbar/Navbar";
import Header from "../../components/header/Header";
import Avatar from "@mui/material/Avatar";
import CssBaseline from "@mui/material/CssBaseline";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import Typography from "@mui/material/Typography";
import Container from "@mui/material/Container";
import { MyCheckbox } from "../../components/myCheckbox/MyCheckbox";
import AuthApiService from "../../adapters/xhr/AuthApiService";
import { AuthContext } from "../../contexts/AuthContext";

export const Login = (props) => {
  const [username, setUsername] = useState("");
  const [usernameErr, setUsernameErr] = useState("");
  const [password, setPassword] = useState("");
  const [passwordErr, setPasswordErr] = useState("");
  const [message, setMessage] = useState(null);
  const navigate = useNavigate();
  const myContext = useContext(MyContext);
  const { loading, error, dispatch } = useContext(AuthContext);

  const navigateToReturnUrl = (returnUrl) => {
    // It's important that we do a replace here so that we remove the callback uri with the
    // fragment containing the tokens from the browser history.
    window.location.replace(returnUrl);
  };

  const getReturnUrl = () => {
    const params = new URLSearchParams(window.location.search);
    const fromQuery = params.get(QueryParameterNames.ReturnUrl);
    if (fromQuery && !fromQuery.startsWith(`${window.location.origin}/`)) {
      // This is an extra check to prevent open redirects.
      throw new Error("Invalid return url. The return url needs to have the same origin as the current page.");
    }
    return fromQuery || `${window.location.origin}/`;
  };

  const login = async () => {
    let isValid = true;
    if (!username) {
      setUsernameErr("Required");
      isValid = false;
    } else setUsernameErr("");
    if (!password) {
      setPasswordErr("Required");
      isValid = false;
    } else setPasswordErr("");
    if (!isValid) return;
    try {
      let result = await AuthApiService.login(username, password);
      if (result) {
        dispatch({ type: "LOGIN_SUCCESS", payload: result.username });
        navigateToReturnUrl(getReturnUrl());
      } else {
        setMessage("Something wrong");
      }
    } catch (err) {
      setMessage("Something wrong");
    }
  };
  return (
    <MyContext.Consumer>
      {(context) => (
        <>
          <Container component="main" maxWidth="xs">
            <CssBaseline />
            <Box
              sx={{
                marginTop: 8,
                display: "flex",
                flexDirection: "column",
                alignItems: "center",
              }}
            >
              <Avatar sx={{ m: 1, bgcolor: "secondary.main" }}>
                <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                Login
              </Typography>
              <Box component="form" noValidate sx={{ mt: 1 }}>
                <MyTextField label={"Username"} value={username} onChange={setUsername} regExp={ValidTextRegExp} helperText={usernameErr} />
                <MyTextField type="password" label={"Password"} value={password} onChange={setPassword} helperText={passwordErr} />
                <MyCheckbox label="Remember me" className="margin top-0 bottom-0" onChange={() => {}} />
                <MyButton fullWidth={true} className="margin bottom-1" onClick={(e) => login()} text={"login"} />
                <Grid container>
                  <Grid item xs>
                    <Link href="/login#" variant="body2">
                      Forgot password?
                    </Link>
                  </Grid>
                  <Grid item>
                    <Link href="/register" variant="body2">
                      {"Don't have an account? Register"}
                    </Link>
                  </Grid>
                </Grid>
                {message && (
                  <Alert variant="filled" severity="error" sx={{ mt: 2, mb: 2 }}>
                    {message}
                  </Alert>
                )}
              </Box>
            </Box>
          </Container>
        </>
      )}
    </MyContext.Consumer>
  );
};
