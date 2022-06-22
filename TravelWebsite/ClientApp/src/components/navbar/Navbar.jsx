import { Link } from "@mui/material";
import "./navbar.css";
import { useEffect, useState } from "react";

const Navbar = () => {
  return (
    <div className="navbar">
      <div className="navContainer">
        <a href="/">
          <span className="logo">lamabooking</span>
        </a>
        <div className="navItems">
          <button className="navButton">Register</button>
          <button className="navButton">Login</button>
        </div>
      </div>
    </div>
  );
};

export default Navbar;
