import { fireEvent, render, screen } from "@testing-library/react";
import { v4 as uuidv4 } from "uuid";
import { Table } from "./Table";
import { Registrations } from "./index";
import { Checkbox } from "@material-ui/core";

/**
 * **NOTE**: as this component is largely an external library, only
 * the most fundamental tests are required for the UI.
 * TODO: Proper triggering of the accept and export functions, as well as
 * their eventual implementation of the API communication should
 * be tested here.
 */


const testAccept = jest.fn(() => Promise.resolve({}));
const testExport = jest.fn(() => Promise.resolve({}));


const setUpSelectedRow = () => {
  const testData = [
    { id: `${uuidv4()}`, name: "John Doe", status: "Pending" },
  ];
  render(
    <Table data={testData} accept={testAccept} export={testExport} />
  );

  const checkbox = screen.getAllByRole("checkbox", {checked: false})[1];
  fireEvent.click(checkbox, { button: 0})
}

global.fetch = jest.fn(() => Promise.resolve({}));

describe("<Registrations/>", () => {
  describe("<Table />", () => {
    it("renders proper data into the table", () => {
      const testData = [
        { id: `${uuidv4()}`, name: "John Doe", status: "Pending" },
        { id: `${uuidv4()}`, name: "Albert Bob", status: "Confirmed" },
        { id: `${uuidv4()}`, name: "Guy Dude", status: "Confirmed" },
        { id: `${uuidv4()}`, name: "Tyler1", status: "Pending" },
      ];

      render(
        <Table data={testData} accept={testAccept} exportData={testExport} />
      );

      testData.forEach(({ id, name, status }) => {
        expect(screen.getByText(id)).toBeInTheDocument();
        expect(screen.getByText(name)).toBeInTheDocument();
        // pretty messy but at least ensures that it's value IS in the doc
        // such that one type of status isn't being left out due to bugs
        expect(screen.getAllByText(status)[0]).toBeInTheDocument();
      });
    });

    it("renders data action buttons on selecting checkbox", () => {
      setUpSelectedRow();
      // check the modal is closed.
      expect(screen.getByTestId("export-data")).toBeInTheDocument();
      expect(screen.getByTestId("accept-app")).toBeInTheDocument();
    });

    it("calls the export function on clicking export icon", () => {
      setUpSelectedRow();

      const exportBtn = screen.getByTitle("Export selected data");
      fireEvent.click(exportBtn, { button: 0});

      expect(testExport).toHaveBeenCalled();
    });

    it("calls the accept applicant function on clicking accept icon", () => {
      setUpSelectedRow();

      const acceptBtn = screen.getByTestId("accept-app");
      fireEvent.click(acceptBtn, { button: 0});

      expect(testAccept).toHaveBeenCalled();
    });


    it("handles empty dataset", () => {
      const testData = [];

      // just needs to redner without error here
      render(
        <Table data={testData} accept={testAccept} exportData={testExport} />
      );
    });
    // any tests beyond this infringe on dependency behaviour and not our own code
  });

  it("should fetch applicant data from faker data or API", () => {
    render(<Registrations />);

    expect(fetch).toHaveBeenCalled();
  });
});
