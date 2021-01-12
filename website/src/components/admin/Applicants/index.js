import React, { useEffect, useState, forwardRef } from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { getAttendees } from "@utils/data";
import MaterialTable from "material-table";
import download from "js-file-download";
import { Sidebar } from "@admin/common/Sidebar";
import { Parser } from "json2csv";
import {
  Search,
  AddBox,
  Clear,
  Edit,
  FilterList,
  FirstPage,
  LastPage,
  Remove,
  ViewColumn,
  ArrowDownward,
  Check,
  ChevronLeft,
  ChevronRight,
  GetApp,
} from "@material-ui/icons";
import "./applicants.css";

// Object that provides table mapping of which icons we want to represent
// the defined icons they have provided in their component.
// See https://material-table.com/#/ for details
const tableIcons = {
  Add: forwardRef((props, ref) => <AddBox {...props} ref={ref} />),
  Clear: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  Edit: forwardRef((props, ref) => <Edit {...props} ref={ref} />),
  Filter: forwardRef((props, ref) => <FilterList {...props} ref={ref} />),
  FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
  LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
  NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
  ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
  SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
  ThirdStateCheck: forwardRef((props, ref) => <Remove {...props} ref={ref} />),
  ViewColumn: forwardRef((props, ref) => <ViewColumn {...props} ref={ref} />)

};


/**
 * Component for the /admin/registrations page
 * See README for figma links to mockup design
 * @param {*} props
 */
export const Registrations = (props) => {
  const [attendees, setAttendees] = useState([]);
  const fields = ["id", "name", "status"];
  const options = { fields };


  const getData = async () => {
    const { users: rows } = await getAttendees();
    setAttendees(rows);
    console.log(rows);
  };

  const exportData = async (data) => {
    try {
      const parser = new Parser(options);
      const csv = parser.parse(data);
      download(csv, "registrations.csv");
    } catch (err) {
      console.log(err);
    }
  }

  const acceptApplication = (e, data) => {
    alert(`Logging applicants that would be accepted in backend.`)
    data.forEach(app => console.log(app))
  }

  useEffect(() => {
    getData();
  }, []);

  return (
    <Container className="applicants" maxWidth="lg">
      <Grid container spacing={5}>
        <Grid item xs={3}>
          <Sidebar />
        </Grid>
        <Grid item xs={9}>
          <MaterialTable
            style={{height: "100%",}}
            options={{
              selection: true
            }}
            actions={[
              {
                tooltip: "Accept selected applications",
                icon: () => <Check {...props} />,
                onClick: (e, data) => acceptApplication(e, data),
              },
              {
                tooltip: "Export selected data",
                icon: () => <GetApp {...props} />,
                onClick: (e, data) => exportData(data),
              }
            ]}
            icons={tableIcons}
            columns={[
              { title: "ID", field: "id" },
              { title: "Name", field: "name" },
              { title: "Status", field: "status"},
            ]}
            data={attendees}
            title="Registrations"
          />
        </Grid>
      </Grid>
    </Container>
  );
};
