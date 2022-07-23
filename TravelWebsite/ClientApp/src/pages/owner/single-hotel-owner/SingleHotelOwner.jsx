import "./singleAdmin.scss";
import Sidebar from "../../../components/sidebarOwner/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import MyTable from "../../../components/myTable/MyTable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import UserApiService from "../../../adapters/xhr/UserApiService";
import { useEffect, useState } from "react";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";
import BookingApiService from "../../../adapters/xhr/BookingApiService";
import { base64ToSrc } from "../../../Utils";
import { Link, useNavigate } from "react-router-dom";
// import Chart from "../../../components/chart/Chart";

const SingleHotelOwner = () => {
  const [hotel, setHotel] = useState({});
  const id = location.pathname.split("/")[3];
  const navigate = useNavigate();
  const fetchHotel = async () => {
    let result = await PropertyApiService.getById(id);
    setHotel(result);
  };
  useEffect(() => {
    fetchHotel();
  }, []);
  const onEdit = () => {
    navigate("/owner/hotels/edit", {
      state: { hotel },
    });
  };
  return (
    <div className="single-hotel">
      <Sidebar />
      <div className="singleContainer">
        <NavbarAdmin />
        <div className="top">
          <div className="left">
            <div className="editButton" onClick={onEdit}>
              Edit
              {/* <Link to={`/owner/hotels/edit`} className="link">
                Edit
              </Link> */}
            </div>
            <h1 className="title">Information</h1>
            <div className="item">
              <img
                src={
                  hotel.images && hotel.images.length > 0
                    ? base64ToSrc(hotel.images[0].file)
                    : ""
                }
                alt=""
                className="itemImg"
              />
              <div className="details">
                <h1 className="itemTitle">{hotel.fullname}</h1>
                <div className="detailItem">
                  <span className="itemKey">Name:</span>
                  <span className="itemValue">{hotel.name}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Type:</span>
                  <span className="itemValue">{hotel.type}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">City:</span>
                  <span className="itemValue">{hotel.city}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Description:</span>
                  <span className="itemValue">{hotel.description}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Features:</span>
                  <span className="itemValue">{hotel.shortDescription}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Address:</span>
                  <span className="itemValue">{hotel.address}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Price:</span>
                  <span className="itemValue">{hotel.price}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Number of kids:</span>
                  <span className="itemValue">{hotel.numberOfKids}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Number of adults:</span>
                  <span className="itemValue">{hotel.numberOfAdults}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Number of rooms:</span>
                  <span className="itemValue">{hotel.numberOfRooms}</span>
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
          <MyTable items={hotel.bookings} />
        </div>
      </div>
    </div>
  );
};

export default SingleHotelOwner;
