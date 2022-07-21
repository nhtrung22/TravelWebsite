import { useContext } from "react";
import { Link } from "react-router-dom";
import { AuthContext } from "../../contexts/AuthContext";
import "./navbar.css";

const Navbar = () => {
  const { user } = useContext(AuthContext);
  return (
    <div className="navbar">
      <div className="navContainer">
        <Link to="/">
          <span className="logo">Booking</span>
        </Link>
        <div className="navItems">
          {!user && (
            <>
              <Link to="/register" style={{ textDecoration: "none" }}>
                <button className="navButton">Register</button>
              </Link>
              <Link to="/login" style={{ textDecoration: "none" }}>
                <button className="navButton">Login</button>
              </Link>
            </>
          )}
          {user && (
            <>
              <Link to="/user" style={{ textDecoration: "none" }}>
                <img
                  src="https://images.pexels.com/photos/941693/pexels-photo-941693.jpeg?auto=compress&cs=tinysrgb&dpr=2&w=500"
                  alt=""
                  className="avatar"
                />
              </Link>
              <Link to="/logout" style={{ textDecoration: "none" }}>
                <button sx={{ ml: 1 }} className="navButton">
                  Logout
                </button>
              </Link>
            </>
          )}
        </div>
      </div>
    </div>
  );
};

export default Navbar;
