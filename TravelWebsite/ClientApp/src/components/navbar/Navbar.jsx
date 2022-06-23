import { Link } from "react-router-dom";
import "./navbar.css";

const Navbar = () => {
  return (
    <div className="navbar">
      <div className="navContainer">
        <a href="/">
          <span className="logo">Booking</span>
        </a>
        <div className="navItems">
          <Link to="/register" style={{ textDecoration: "none" }}>
            <button className="navButton">Register</button>
          </Link>
          <Link to="/login" style={{ textDecoration: "none" }}>
            <button className="navButton">Login</button>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
