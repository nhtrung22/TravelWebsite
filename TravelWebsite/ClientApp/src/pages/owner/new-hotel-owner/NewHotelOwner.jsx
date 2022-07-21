import "./newAdmin.scss";
import Sidebar from "../../../components/sidebarOwner/Sidebar";
import DriveFolderUploadOutlinedIcon from "@mui/icons-material/DriveFolderUploadOutlined";
import { useState } from "react";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import { useNavigate } from "react-router-dom";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";
import { toBase64 } from "../../../Utils";

const NewHotelOwner = ({ inputs, title }) => {
  const [files, setFiles] = useState([]);
  const [data, setData] = useState({});
  const navigate = useNavigate();
  const add = async (event) => {
    event.preventDefault();
    try {
      await PropertyApiService.add({
        ...data,
        images: await Promise.all(
          Array.from(files).map(async (item) => ({
            fileName: item.name,
            file: await toBase64(item),
          }))
        ),
      });
      navigate("/owner/hotels", { replace: true });
    } catch (err) {
      console.log(err);
    }
  };
  return (
    <div className="new-hotel">
      <Sidebar />
      <div className="newContainer">
        <NavbarAdmin />
        <div className="top">
          <h1>{title}</h1>
        </div>
        <div className="bottom">
          <div className="left">
            {files && files.length > 0 ? (
              Array.from(files).map((file, index) => (
                <img key={index} src={URL.createObjectURL(file)} alt="" />
              ))
            ) : (
              <img
                src={
                  "https://icon-library.com/images/no-image-icon/no-image-icon-0.jpg"
                }
                alt=""
              />
            )}
          </div>
          <div className="right">
            <form>
              <div className="formInput">
                <label htmlFor="file">
                  Image: <DriveFolderUploadOutlinedIcon className="icon" />
                </label>
                <input
                  multiple
                  type="file"
                  id="file"
                  onChange={(e) => {
                    setFiles(e.target.files);
                  }}
                  style={{ display: "none" }}
                />
              </div>

              {inputs.map((input) => (
                <div className="formInput" key={input.id}>
                  <label>{input.label}</label>
                  <input
                    name={input.key}
                    onChange={(e) =>
                      setData({ ...data, [input.key]: e.target.value })
                    }
                    type={input.type}
                    placeholder={input.placeholder}
                  />
                </div>
              ))}
              <div className="formInput">
                <button onClick={add}>Send</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default NewHotelOwner;
