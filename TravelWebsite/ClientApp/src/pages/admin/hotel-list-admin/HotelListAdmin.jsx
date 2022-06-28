import "./listadmin.scss";
import Sidebar from "../../../components/sidebar/Sidebar";
import Datatable from "../../../components/datatable/Datatable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import { useEffect, useState } from "react";
import { hotelColumns } from "../../../datatablesource";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";

const HotelListAdmin = () => {
  const [data, setData] = useState([]);
  useEffect(() => {
    async function fetchData() {
      const response = await PropertyApiService.getAll();
      setData(response.items);
    }
    fetchData();
  }, []);
  return (
    <div className="list">
      <Sidebar />
      <div className="listContainer-admin">
        <NavbarAdmin />
        <Datatable userRows={data} columns={hotelColumns} />
      </div>
    </div>
  );
};

export default HotelListAdmin;
