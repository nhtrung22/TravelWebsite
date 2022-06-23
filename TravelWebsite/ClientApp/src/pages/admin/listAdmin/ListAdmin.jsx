import "./listadmin.scss"
import Sidebar from "../../../components/sidebar/Sidebar"
import Navbar from "../../../components/navbar/Navbar"
import Datatable from "../../../components/datatable/Datatable"
import NavbarAdmin from "../../../components/navbarAdmin/NavbarAdmin"

const ListAdmin = () => {
  return (
    <div className="list">
      <Sidebar/>
      <div className="listContainer-admin">
        <NavbarAdmin/>
        <Datatable/>
      </div>
    </div>
  )
}

export default ListAdmin