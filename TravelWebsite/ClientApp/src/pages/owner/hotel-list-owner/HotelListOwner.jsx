import "./listadmin.scss";
import Sidebar from "../../../components/sidebarOwner/Sidebar";
import Datatable from "../../../components/datatable/Datatable";
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin";
import { useEffect, useState } from "react";
import { hotelColumns } from "../../../datatablesource";
import PropertyApiService from "../../../adapters/xhr/PropertyApiService";

const HotelListOwner = () => {
  const [data, setData] = useState([]);
  const fetchData = async () => {
    const response = await PropertyApiService.getAll();
    setData(response.items);
  };
  useEffect(() => {
    fetchData();
  }, []);
  const handleDelete = async (id) => {
    await PropertyApiService.deleteById(id);
    await fetchData();
  };
  return (
    <div className="list">
      <Sidebar />
      <div className="listContainer-admin">
        <NavbarAdmin />
        <Datatable userRows={data} columns={hotelColumns} handleDelete={handleDelete} />
      </div>
    </div>
  );
};

export default HotelListOwner;
