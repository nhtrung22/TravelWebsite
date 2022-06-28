import "./homeadmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import Widget from "../../../components/widget/Widget";
import FeaturedAdmin from "../../../components/featuredAdmin/FeaturedAdmin";
// import Chart from "../../../components/chart/Chart";
import MyTable from "../../../components/myTable/MyTable";
import { useEffect, useState } from "react";
import AdminApiService from "../../../adapters/xhr/AdminApiService";

export const HomeAdmin = () => {
  const [statistics, setStatistics] = useState({});
  const fetchStatistics = async () => {
    let result = await AdminApiService.getStatistics();
    setStatistics(result);
  };
  useEffect(() => {
    fetchStatistics();
  }, []);
  return (
    <div className="home">
      <Sidebar />
      <div className="homeAdminContainer">
        <NavbarAdmin />
        <div className="widgets">
          <Widget type="user" amount={statistics.numberOfUsers} />
          <Widget type="order" amount={statistics.numberOfOrders} />
          <Widget type="earning" />
          <Widget type="balance" />
        </div>
        {/* <div className="charts">
          <FeaturedAdmin />
          <Chart title="Last 6 Months (Revenue)" aspect={2 / 1} />
        </div> */}
        <div className="listContainer">
          <div className="listTitle">Latest Transactions</div>
          <MyTable />
        </div>
      </div>
    </div>
  );
};

export default HomeAdmin;
