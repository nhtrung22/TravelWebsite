import { Link } from "@mui/material";
import "./navbar.css";
import { useEffect, useState } from "react";

const Navbar = () => {
  return (
    <div className="navbar">
      <div className="navContainer">
        <a href="/">
          <span className="logo">Booking</span>
        </a>
        <div className="navItems">
          <button className="navButton"><a href="/register">Register</a></button>
          <button className="navButton"><a href="/login">Login</a></button>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
