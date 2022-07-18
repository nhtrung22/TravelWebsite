import { UserType } from "./Constant";
import { string_of_enum } from "./Utils";

export const userColumns = [
  { field: "id", headerName: "ID", width: 70 },
  {
    field: "user",
    headerName: "User",
    width: 230,
    renderCell: (params) => {
      return (
        <div className="cellWithImg">
          <img className="cellImg" src={params.row.avatar} alt="avatar" />
          {params.row.username}
        </div>
      );
    },
  },
  {
    field: "email",
    headerName: "Email",
    width: 230,
  },
  {
    field: "userType",
    headerName: "User type",
    width: 230,
    valueGetter: (params) => string_of_enum(UserType, params.row.userType),
  },
  {
    field: "age",
    headerName: "Age",
    width: 100,
  },
  {
    field: "phoneNumber",
    headerName: "Phone number",
    width: 200,
  },
  // {
  //   field: "status",
  //   headerName: "Status",
  //   width: 160,
  //   renderCell: (params) => {
  //     return <div className={`cellWithStatus ${params.row.status}`}>{params.row.status}</div>;
  //   },
  // },
];

export const hotelColumns = [
  { field: "id", headerName: "ID", width: 250 },
  {
    field: "name",
    headerName: "Name",
    width: 150,
  },
  {
    field: "type",
    headerName: "Type",
    width: 100,
    valueGetter: (params) => params.row.type.name,
  },
  // {
  //   field: "title",
  //   headerName: "Title",
  //   width: 230,
  // },
  {
    field: "city",
    headerName: "City",
    width: 100,
    valueGetter: (params) => params.row.city.name,
  },
];