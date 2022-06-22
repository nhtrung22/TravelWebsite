import {
  Box,
  Checkbox,
  Container,
  CssBaseline,
  FormControlLabel,
  Grid,
  Link,
  Typography,
  Avatar,
} from "@mui/material";
import LockOutlinedIcon from "@mui/icons-material/LockOutlined";
import React, { useCallback, useContext, useState, useTransition } from "react";
import { Navigate, useNavigate } from "react-router-dom";
import { Alert } from "reactstrap";
// import AuthApiService from "../../api/AuthApiService";
import { MyButton } from "../../components/myButton/MyButton";
import { MyTextField } from "../../components/myTextField/MyTextField";
import { EmailRegExp, ValidTextRegExp } from "../../Constant";
import MyContext from "../../contexts/MyContext";
import Navbar from "../../components/navbar/Navbar";
import Header from "../../components/header/Header";

export const Register = (props) => {
  const [username, setUsername] = useState("");
  const [usernameErr, setUsernameErr] = useState("");
  const [email, setEmail] = useState("");
  const [emailErr, setEmailErr] = useState("");
  const [password, setPassword] = useState("");
  const [passwordErr, setPasswordErr] = useState("");
  const [confirmPassword, setConfirmPassword] = useState("");
  const [confirmPasswordErr, setConfirmPasswordErr] = useState("");
  const [message, setMessage] = useState("");
  const navigate = useNavigate();
  const myContext = useContext(MyContext);

  const register = async () => {
    let isValid = true;
    let validEmail = new RegExp(EmailRegExp);
    if (username == "") {
      setUsernameErr("Required");
      isValid = false;
    } else {
      setUsernameErr("");
    }
    if (email == "") {
      setEmailErr("Required");
      isValid = false;
    } else if (!validEmail.tes(email)) {
      setEmailErr("Invalid");
      isValid = false;
    } else setEmailErr("");
    if (password == "") {
      setPasswordErr("Required");
      isValid = false;
    } else if (password.length <= 5) {
      setPasswordErr("Should be more than 5 characters");
      isValid = false;
    } else setPasswordErr("");
    if (confirmPassword == "") {
      setConfirmPasswordErr("Required");
      isValid = false;
    } else if (confirmPassword != password) {
      setConfirmPasswordErr("Doesn't match");
      isValid = false;
    } else {
      setConfirmPasswordErr("");
    }
    // if (isValid) {
    //   let result = await AuthApiService.register({
    //     username: username,
    //     password: password,
    //   });
    //   if (result) {
    //     navigate("/login", { replace: true });
    //   }
    // }
  };
  return (
    <MyContext.Consumer>
      {(context) => (
        <>
          <Navbar />
          <Header type="list" />
          <Container component="main" maxWidth="xs" className="margin bottom-4">
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
                Register
              </Typography>
              <Box component="form" noValidate sx={{ mt: 1 }}>
                <MyTextField
                  label={"Username"}
                  value={username}
                  onChange={setUsername}
                  regExp={ValidTextRegExp}
                  helperText={usernameErr}
                />
                <MyTextField
                  label={"Email"}
                  value={email}
                  onChange={setEmail}
                  regExp={ValidTextRegExp}
                  helperText={emailErr}
                />
                <MyTextField
                  type="password"
                  label={"Password"}
                  value={password}
                  onChange={setPassword}
                  helperText={passwordErr}
                />
                <MyTextField
                  type="password"
                  label={"Confirm password"}
                  value={confirmPassword}
                  onChange={setConfirmPassword}
                  helperText={confirmPasswordErr}
                />
                <MyButton
                  fullWidth={true}
                  className="margin bottom-1 right-1"
                  onClick={(e) => register()}
                  text={"register"}
                />
                <Grid container>
                  <Grid item xs>
                    <Link href="/register#" variant="body2">
                      Forgot password?
                    </Link>
                  </Grid>
                  <Grid item>
                    <Link href="/login" variant="body2">
                      {"Have an account? Login"}
                    </Link>
                  </Grid>
                </Grid>
                {message && (
                  <Alert
                    variant="filled"
                    severity="error"
                    className="margin top-1 bottom-1"
                  >
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
