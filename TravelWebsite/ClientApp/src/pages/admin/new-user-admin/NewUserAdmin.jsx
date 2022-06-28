import "./newAdmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import DriveFolderUploadOutlinedIcon from "@mui/icons-material/DriveFolderUploadOutlined";
import { useState } from "react";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import UserApiService from "../../../adapters/xhr/UserApiService";
import { useNavigate } from "react-router-dom";

const NewUserAdmin = ({ inputs, title }) => {
  const [file, setFile] = useState("");
  const [user, setUser] = useState({});
  const navigate = useNavigate();
  const add = async (event) => {
    event.preventDefault();
    try {
      await UserApiService.create(user);
      navigate("/admin/users", { replace: true });
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div className="new">
      <Sidebar />
      <div className="newContainer">
        <NavbarAdmin />
        <div className="top">
          <h1>{title}</h1>
        </div>
        <div className="bottom">
          <div className="left">
            <img src={file ? URL.createObjectURL(file) : "https://icon-library.com/images/no-image-icon/no-image-icon-0.jpg"} alt="" />
          </div>
          <div className="right">
            <form>
              <div className="formInput">
                <label htmlFor="file">
                  Image: <DriveFolderUploadOutlinedIcon className="icon" />
                </label>
                <input type="file" id="file" onChange={(e) => setFile(e.target.files[0])} style={{ display: "none" }} />
              </div>

              {inputs.map((input) => (
                <div className="formInput" key={input.id}>
                  <label>{input.label}</label>
                  <input
                    name={input.key}
                    onChange={(e) => setUser({ ...user, [input.key]: e.target.value })}
                    type={input.type}
                    placeholder={input.placeholder}
                  />
                </div>
              ))}
              <button onClick={add}>Send</button>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewUserAdmin;
