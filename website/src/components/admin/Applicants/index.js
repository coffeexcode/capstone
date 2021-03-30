import React, { useEffect, useState, forwardRef } from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { v1, exportData } from "@utils/data";
import { Sidebar } from "@admin/common/Sidebar";
import Loader from "react-loader-spinner";
import { Table } from "./Table";
import "./applicants.css";
import "react-loader-spinner/dist/loader/css/react-spinner-loader.css";

/**
 * Component for the /admin/registrations page that lists
 * all applicants for your event, with the ability to review
 * and act on these applicants through a drop down panel
 * 
 * See README for figma links to mockup design
 */
export const Registrations = (props) => {
  const [attendees, setAttendees] = useState([]);
  const fields = ["id", "name", "status"];
  const options = { fields };

  const getData = async () => {
    const rows = await v1.getAttendees();
    setAttendees(rows);
  };

  const update = (data) => {
    const tmp = [...attendees];
    setAttendees(tmp.map(v => {
      if (v.id && v.id === data.id) {
        return data;
      }
      return v;
    }));
  }

  useEffect(() => {
    getData();
  }, []);

  return (
    <Container
      data-testid="registrations-page"
      className="applicants"
      maxWidth="lg"
    >
      <Grid container spacing={5}>
        <Grid item xs={3}>
          <Sidebar />
        </Grid>
        <Grid item xs={9}>
          {attendees.length > 0 ? (
            <Table
              export={exportData}
              data={attendees}
              update={update}
            />
          ) : (
            <Loader
              style={{marginTop: "20%"}}
              type="Puff"
              color="#6b9cd5"
              height={100}
              width={100}
              timeout={3000} //3 secs
            />
          )}
        </Grid>
      </Grid>
    </Container>
  );
};
