import React, { useEffect, useState, forwardRef } from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { getAttendees } from "@utils/data";
import download from "js-file-download";
import { Sidebar } from "@admin/common/Sidebar";
import { Parser } from "json2csv";
import { Table } from "./Table";
import "./applicants.css";

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
  };

  const acceptApplication = (e, data) => {
    alert(`Logging applicants that would be accepted in backend.`);
    data.forEach((app) => console.log(app));
  };

  useEffect(() => {
    getData();
  }, []);

  return (
    <Container data-testid="registrations-page" className="applicants" maxWidth="lg">
      <Grid container spacing={5}>
        <Grid item xs={3}>
          <Sidebar />
        </Grid>
        <Grid item xs={9}>
          <Table
            accept={acceptApplication}
            export={exportData}
            data={attendees}
          />
        </Grid>
      </Grid>
    </Container>
  );
};
