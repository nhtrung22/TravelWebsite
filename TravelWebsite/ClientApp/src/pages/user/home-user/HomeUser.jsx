import "./homeadmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import Widget from "../../../components/widget/Widget";
import FeaturedAdmin from "../../../components/featuredAdmin/FeaturedAdmin";
// import Chart from "../../../components/chart/Chart";
import MyTable from "../../../components/myTable/MyTable";
import { useEffect, useState } from "react";
import AdminApiService from "../../../adapters/xhr/AdminApiService";
import BookingApiService from "../../../adapters/xhr/BookingApiService";

export const HomeUser = () => {
  const [bookings, setBookings] = useState([]);
  const fetchBookings = async () => {
    let result = await BookingApiService.getAll();
    setBookings(result);
  };
  useEffect(() => {
    fetchBookings();
  }, []);
  return (
    <div className="home">
      <div className="homeAdminContainer">
        <NavbarAdmin />
        <div className="widgets">
          <Widget type="order" />
          <Widget type="earning" />
          <Widget type="balance" />
        </div>
        {/* <div className="charts">
          <FeaturedAdmin />
          <Chart title="Last 6 Months (Revenue)" aspect={2 / 1} />
        </div> */}
        <div className="listContainer">
          <div className="listTitle">Bookings</div>
          <MyTable items={bookings} />
        </div>
      </div>
    </div>
  );
};

export default HomeUser;
