import "./listadmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import Datatable from "../../../components/datatable/Datatable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import { useEffect, useState } from "react";
import UserApiService from "../../../adapters/xhr/UserApiService";
import { userColumns } from "../../../datatablesource";

const UserListAdmin = () => {
  const [data, setData] = useState([]);
  const fetchData = async () => {
    const response = await UserApiService.getAll();
    setData(response);
  };
  useEffect(() => {
    fetchData();
  }, []);
  const handleDelete = async (id) => {
    await UserApiService.deleteById(id);
    await fetchData();
  };
  return (
    <div className="list">
      <Sidebar />
      <div className="listContainer-admin">
        <NavbarAdmin />
        <Datatable userRows={data} columns={userColumns} handleDelete={handleDelete} />
      </div>
    </div>
  );
};

export default UserListAdmin;
