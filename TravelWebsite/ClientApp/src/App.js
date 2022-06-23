import { useContext } from "react";
import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Header from "./components/header/Header";
import Navbar from "./components/navbar/Navbar";
import { AuthContext } from "./contexts/AuthContext";
import { userInputs } from "./formSource";
import { HomeAdmin } from "./pages/admin/homeAdmin/HomeAdmin";
import ListAdmin from "./pages/admin/listAdmin/ListAdmin";
import NewAdmin from "./pages/admin/newAdmin/NewAdmin";
import SingleAdmin from "./pages/admin/singleAdmin/SingleAdmin";
import Home from "./pages/home/Home";
import Hotel from "./pages/hotel/Hotel";
import List from "./pages/list/List";
// import "./styles/main.scss";
import { Login } from "./pages/login/Login";
import { Register } from "./pages/register/Register";

function App() {
  const ProtectedRoute = ({ children }) => {
    const { user } = useContext(AuthContext);

    if (!user) {
      return <Navigate to="/admin/login" />;
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
        </Route>

        <Route path="users">
          <Route index element={<ListAdmin />} />
          <Route path=":userId" element={<SingleAdmin />} />
          <Route path="new" element={<NewAdmin inputs={userInputs} title="Add New User" />} />
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
        <Route path="/register" element={<Register />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
