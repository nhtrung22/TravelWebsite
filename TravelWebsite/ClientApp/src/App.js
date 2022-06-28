import { useContext } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Header from "./components/header/Header";
import Navbar from "./components/navbar/Navbar";
import { QueryParameterNames } from "./Constant";
import { AuthContext } from "./contexts/AuthContext";
import { hotelInputs, userInputs } from "./formSource";
import { HomeAdmin } from "./pages/admin/home-admin/HomeAdmin";
import UserListAdmin from "./pages/admin/user-list-admin/UserListAdmin";
import HotelListAdmin from "./pages/admin/hotel-list-admin/HotelListAdmin";
import NewAdmin from "./pages/admin/new-user-admin/NewUserAdmin";
import Home from "./pages/home/Home";
import Hotel from "./pages/hotel/Hotel";
import List from "./pages/list/List";
// import "./styles/main.scss";
import { Login } from "./pages/login/Login";
import { Logout } from "./pages/logout/Logout";
import { Register } from "./pages/register/Register";
import SingleHotelAdmin from "./pages/admin/single-hotel-admin/SingleHotelAdmin";
import SingleUserAdmin from "./pages/admin/single-user-admin/SingleUserAdmin";
import NewHotelAdmin from "./pages/admin/new-hotel-admin/NewHotelAdmin";
import NewUserAdmin from "./pages/admin/new-user-admin/NewUserAdmin";

function App() {
  const ProtectedRoute = ({ children }) => {
    const { user } = useContext(AuthContext);
    if (!user) {
      var link = document.createElement("a");
      link.href = window.location.pathname;
      const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
      const redirectUrl = `/login?${QueryParameterNames.ReturnUrl}=${encodeURI(returnUrl)}`;
      return <Navigate to={redirectUrl} />;
    }
    return children;
  };
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/admin">
          <Route
            index
            element={
              <ProtectedRoute>
                <HomeAdmin />
              </ProtectedRoute>
            }
          />
          <Route path="/admin/login" element={<Login />} />
          <Route path="users">
            <Route
              index
              element={
                <ProtectedRoute>
                  <UserListAdmin />
                </ProtectedRoute>
              }
            />
            <Route path=":userId" element={<SingleUserAdmin />} />
            <Route path="new" element={<NewUserAdmin inputs={userInputs} title="Add New User" />} />
          </Route>
          <Route path="hotels">
            <Route
              index
              element={
                <ProtectedRoute>
                  <HotelListAdmin />
                </ProtectedRoute>
              }
            />
            <Route path=":hotelId" element={<SingleHotelAdmin />} />
            <Route path="new" element={<NewHotelAdmin inputs={hotelInputs} title="Add New Hotel" />} />
          </Route>
        </Route>

        <Route path="/" element={<Home />} />
        <Route path="/hotels" element={<List />} />
        <Route path="/hotels/:id" element={<Hotel />} />
        <Route
          path="/login"
          element={
            <>
              <Navbar />
              <Header type="list" />
              <Login />
            </>
          }
        />
        <Route path="/logout" element={<Logout />} />
        <Route path="/register" element={<Register />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
