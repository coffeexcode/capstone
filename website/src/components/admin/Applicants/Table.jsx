import React, { forwardRef } from "react";
import MaterialTable from "material-table";
import { Details } from "./Details";
import {
  Search,
  Clear,
  FirstPage,
  LastPage,
  ArrowDownward,
  Check,
  ChevronLeft,
  ChevronRight,
  GetApp,
} from "@material-ui/icons";


// Object that provides table mapping of which icons we want to represent
// the defined icons they have provided in their component.
// See https://material-table.com/#/ for details
const tableIcons = {
  FirstPage: forwardRef((props, ref) => <FirstPage {...props} ref={ref} />),
  LastPage: forwardRef((props, ref) => <LastPage {...props} ref={ref} />),
  NextPage: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
  PreviousPage: forwardRef((props, ref) => <ChevronLeft {...props} ref={ref} />),
  ResetSearch: forwardRef((props, ref) => <Clear {...props} ref={ref} />),
  Search: forwardRef((props, ref) => <Search {...props} ref={ref} />),
  SortArrow: forwardRef((props, ref) => <ArrowDownward {...props} ref={ref} />),
  DetailPanel: forwardRef((props, ref) => <ChevronRight {...props} ref={ref} />),
};

/**
 * Component to wrap the material table configuration we are using.
 * @param {fn} props.export Method for generating an xml file representing table data 
 */
export const Table = (props) => {

  return (
    <MaterialTable
            style={{height: "100%",}}
            options={{
              selection: true
            }}
            actions={[
              {
                tooltip: "Export selected data",
                icon: () => <GetApp data-testid="export-data" />,
                onClick: (e, data) => props.export(data),
              }
            ]}
            icons={tableIcons}
            columns={[
              { title: "ID", field: "id" },
              { title: "Name", field: "name" },
              { title: "Status", field: "status"},
              { title: "Age", field: "age" },
              { title: "Email", field: "email"}
            ]}
            data={props.data}
            title="Registrations"
            detailPanel={rowData => {
              return (
                <Details data={rowData} update={props.update} />
              )
            }}
          />
  )
}