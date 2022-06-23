import "./homeadmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import Widget from "../../../components/widget/Widget";
import FeaturedAdmin from "../../../components/featuredAdmin/FeaturedAdmin";
// import Chart from "../../../components/chart/Chart";
import MyTable from "../../../components/myTable/MyTable";

export const HomeAdmin = () => {
  return (
    <div className="home">
      <Sidebar />
      <div className="homeAdminContainer">
        <NavbarAdmin />
        <div className="widgets">
          <Widget type="user" />
          <Widget type="order" />
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
