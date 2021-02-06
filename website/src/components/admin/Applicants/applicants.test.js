import { render, screen } from "@testing-library/react";
import { v4 as uuidv4 } from "uuid";
import { Table } from "./Table";
import { Registrations } from "./index";
import { ExpansionPanelActions } from "@material-ui/core";

/**
 * **NOTE**: as this component is largely an external library, only
 * the most fundamental tests are required for the UI.
 * TODO: Proper triggering of the accept and export functions, as well as 
 * their eventual implementation of the API communication should
 * be tested here.
 */

const testAccept = (state) => {
  state["accept"] = true;
};

const testExport = (state) => {
  state["export"] = true;
};

// not sure how select an item with testing api :/
// test("triggering data manipulation methods", () => {
//   const testState = {
//     accept: false,
//     export: false,
//   };

//   // we aren't testing data so empty array is sufficient
//   const testData = [];

//   render(<Table data={testData} accept={testAccept} exportData={testExport} />);

//   const acceptButton = screen.getByTestId("accept-app");
//   fireEvent.click(acceptButton, { button: 0 });

//   expect(testState["accept"])
// });

test("table data passed to props is correct", () => {


  const testData = [
    { id: `${uuidv4()}`, name: "John Doe", status: "Pending" },
    { id: `${uuidv4()}`, name: "Albert Bob", status: "Confirmed" },
    { id: `${uuidv4()}`, name: "Guy Dude", status: "Confirmed" },
    { id: `${uuidv4()}`, name: "Tyler1", status: "Pending" },
  ];

  render(<Table data={testData} accept={testAccept} exportData={testExport} />);

  testData.forEach(({id, name, status}) => {
    expect(screen.getByText(id)).toBeInTheDocument();
    expect(screen.getByText(name)).toBeInTheDocument();
    // pretty messy but at least ensures that it's value IS in the doc
    // such that one type of status isn't being left out due to bugs
    expect(screen.getAllByText(status)[0]).toBeInTheDocument();
  })
});

test("handles empty dataset", () => {
  const testData = [];

  // just needs to redner without error here
  render(<Table data={testData} accept={testAccept} exportData={testExport} />);
});