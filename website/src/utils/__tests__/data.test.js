import { getAttendees, exportData, acceptApplications } from "../data";


describe("Data Utility Methods", () => {
  it("should be able to fetch from the api", done => {
    const callback = (data) => {
      try {
        expect(data).anything();
        done();
      } catch (error) {
        done(error);
      }
    }

    getAttendees().then(callback);
  });
});

describe("Export Table Data", () => {
  // relies mostly on external library, just ensure it doesn't crash
  // on call for now.
  it("should be able to create csv file for download", () => {
    const data = [{id: "1", name: "Bob", status: "hi"}];
    const callback = (data) => {
      try {
        expect(data).anything();
        done();
      } catch (error) {
        done(error);
      }
    }

    exportData(data).then(callback);
  });
});