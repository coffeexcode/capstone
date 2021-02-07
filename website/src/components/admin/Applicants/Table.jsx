import React, { forwardRef } from "react";
import MaterialTable from "material-table";
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

export const Table = (props) => {
  return (
    <MaterialTable
            style={{height: "100%",}}
            options={{
              selection: true
            }}
            actions={[
              {
                tooltip: "Accept selected applications",
                icon: () => <Check data-testid="accept-app" {...props} />,
                onClick: (e, data) => props.accept(e, data),
              },
              {
                tooltip: "Export selected data",
                icon: () => <GetApp data-testid="export-data" {...props} />,
                onClick: (e, data) => props.export(data),
              }
            ]}
            icons={tableIcons}
            columns={[
              { title: "ID", field: "id" },
              { title: "Name", field: "name" },
              { title: "Status", field: "status"},
            ]}
            data={props.data}
            title="Registrations"
          />
  )
}