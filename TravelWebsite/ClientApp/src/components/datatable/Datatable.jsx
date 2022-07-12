import "./datatable.scss";
import { DataGrid } from "@mui/x-data-grid";
import { Link } from "react-router-dom";

const Datatable = (props) => {
  const path = location.pathname.split("/")[2];
  const actionColumn = [
    {
      field: "action",
      headerName: "Action",
      width: 200,
      renderCell: (params) => {
        return (
          <div className="cellAction">
            <Link to={`/admin/${path}/${params.row.id}`} style={{ textDecoration: "none" }}>
              <div className="viewButton">View</div>
            </Link>
            <div className="deleteButton" onClick={() => props.handleDelete(params.row.id)}>
              Delete
            </div>
          </div>
        );
      },
    },
  ];
  return (
    <div className="datatable">
      <div className="datatableTitle">
        Add New
        <Link to={`/admin/${path}/new`} className="link">
          Add New
        </Link>
      </div>
      <DataGrid
        className="datagrid"
        rows={props.userRows}
        columns={props.columns.concat(actionColumn)}
        pageSize={9}
        rowsPerPageOptions={[9]}
        checkboxSelection
      />
    </div>
  );
};

export default Datatable;
