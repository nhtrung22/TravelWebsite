import "./singleAdmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import Navbar from "../../../components/navbar/Navbar";
import MyTable from "../../../components/myTable/MyTable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import UserApiService from "../../../adapters/xhr/UserApiService";
import { useEffect, useState } from "react";
// import Chart from "../../../components/chart/Chart";

const SingleUserAdmin = () => {
  const [user, setUser] = useState({});
  const id = location.pathname.split("/")[3];
  const fetchUser = async () => {
    let result = await UserApiService.getById(id);
    setUser(result);
  };
  useEffect(() => {
    fetchUser();
  }, []);
  return (
    <div className="single">
      <Sidebar />
      <div className="singleContainer">
        <NavbarAdmin />
        <div className="top">
          <div className="left">
            <div className="editButton">Edit</div>
            <h1 className="title">Information</h1>
            <div className="item">
              <img src={user.avatar} alt="" className="itemImg" />
              <div className="details">
                <h1 className="itemTitle">{user.fullname}</h1>
                <div className="detailItem">
                  <span className="itemKey">Email:</span>
                  <span className="itemValue">{user.email}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Phone:</span>
                  <span className="itemValue">{user.phoneNumber}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Address:</span>
                  <span className="itemValue">{user.address}</span>
                </div>
                <div className="detailItem">
                  <span className="itemKey">Country:</span>
                  <span className="itemValue">USA</span>
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

export default SingleUserAdmin;
