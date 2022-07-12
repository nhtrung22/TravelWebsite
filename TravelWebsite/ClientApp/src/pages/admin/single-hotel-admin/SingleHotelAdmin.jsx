import "./singleAdmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import MyTable from "../../../components/myTable/MyTable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import UserApiService from "../../../adapters/xhr/UserApiService";
import { useEffect, useState } from "react";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";
import BookingApiService from "../../../adapters/xhr/BookingApiService";
import { base64ToSrc } from "../../../Utils";
// import Chart from "../../../components/chart/Chart";

const SingleHotelAdmin = () => {
  const [hotel, setHotel] = useState({});
  const id = location.pathname.split("/")[3];
  const fetchHotel = async () => {
    let result = await PropertyApiService.getById(id);
    setHotel(result);
  };
  useEffect(() => {
    fetchHotel();
  }, []);
  return (
    <div className="single-hotel">
      <Sidebar />
      <div className="singleContainer">
        <NavbarAdmin />
        <div className="top">
          <div className="left">
            <div className="editButton">Edit</div>
            <h1 className="title">Information</h1>
            <div className="item">
              <img src={hotel.images && hotel.images.length > 0 ? base64ToSrc(hotel.images[0].file) : ""} alt="" className="itemImg" />
              <div className="details">
                <h1 className="itemTitle">{hotel.fullname}</h1>
                <div className="detailItem">
                  <span className="itemKey">Name:</span>
                  <span className="itemValue">{hotel.name}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Type:</span>
                  <span className="itemValue">{hotel.type?.name}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Description:</span>
                  <span className="itemValue">{hotel.description}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Address:</span>
                  <span className="itemValue">{hotel.address}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Price:</span>
                  <span className="itemValue">{hotel.price}</span>
                </div>
              </div>
            </div>
          </div>
          {/* <div className="right">
            <Chart aspect={3 / 1} title="User Spending ( Last 6 Months)" />
          </div> */}
        </div>
        <div className="bottom">
          <h1 className="title">Last Transactions</h1>
          <MyTable />
        </div>
      </div>
    </div>
  );
};

export default SingleHotelAdmin;
