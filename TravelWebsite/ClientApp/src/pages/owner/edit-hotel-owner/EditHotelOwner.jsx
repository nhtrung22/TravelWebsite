import "./newAdmin.scss";
import Sidebar from "../../../components/sidebarOwner/Sidebar";
import DriveFolderUploadOutlinedIcon from "@mui/icons-material/DriveFolderUploadOutlined";
import { useState } from "react";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import { useLocation, useNavigate } from "react-router-dom";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";
import { base64ToSrc, toBase64 } from "../../../Utils";

const EditHotelOwner = ({ inputs, title }) => {
  const location = useLocation();
  const [files, setFiles] = useState(location.state.hotel.images);
  const [data, setData] = useState(location.state.hotel);
  const navigate = useNavigate();
  const update = async (event) => {
    event.preventDefault();
    try {
      await PropertyApiService.update(data.id, {
        ...data,
        images: await Promise.all(
          Array.from(files).map(async (item) =>
            typeof item.file === "string"
              ? { ...item }
              : {
                  fileName: item.name,
                  file: await toBase64(item),
                }
          )
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
              Array.from(files).map((item, index) => (
                <img
                  key={index}
                  src={
                    typeof item.file === "string"
                      ? base64ToSrc(item.file)
                      : URL.createObjectURL(item)
                  }
                  alt=""
                />
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
                    value={data[input.key]}
                  />
                </div>
              ))}
              <div className="formInput">
                <button onClick={update}>Send</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  );
};

export default EditHotelOwner;
