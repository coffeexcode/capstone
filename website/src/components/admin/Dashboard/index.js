import React, { useEffect, useState } from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@admin/common/Sidebar";
import { NumberWidget } from "@admin/common/NumberWidget";
import { NavigationPanel } from "./NavigationPanel";
import { getAttendees } from "@utils/data";
import { getCount } from "@utils/stats";
import { PieChartWidget } from "@admin/common/PieChartWidget";
import "./dashboard.css";

/**
 * Component for the /admin landing page
 * See README for figma links to mockup design and purpose
 */
export const Dashboard = (props) => {

  const [attendees, setAttendees] = useState([]);
  
  const getData = async () => {
    const { users: rows } = await getAttendees();
    setAttendees(rows);
  };

  useEffect(() => {
    getData();
  }, []);

  const applicationsData = {
    labels: ['Pending', 'Accepted', 'Rejected'],
    datasets: [
      {
        data: [getCount(attendees, "status", "Pending"), getCount(attendees, "status", "Accepted"), getCount(attendees, "status", "Rejected")],
        backgroundColor: [
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(255, 99, 132, 0.2)'
        ],
        borderColor: [
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(255, 99, 132, 1)'],
          borderWidth: 1,
        },
      ],
    }

  return (
    <Container className="dashboard" maxWidth="lg">
      <Grid container spacing={5}>
        <Grid item xs={3}>
          <Sidebar />
        </Grid>
        <Grid item xs={9}>
          <Typography
            className="dashboard-title"
            color="textSecondary"
            component="h4"
            variant="h4"
          >
            Event Dashboard
          </Typography>
          <Grid container spacing={2}>
            {/* Application/Event Traffic overview */}
            <Grid className="application-metric" item xs={4}>
              <NumberWidget heading="Pending Applications" value={getCount(attendees, "status", "Pending")} />
            </Grid>
            <Grid className="application-metric" item xs={4}>
              <NumberWidget heading="Event Views" value="2670" />
            </Grid>
            <Grid className="application-metric" item xs={4}>
              <NumberWidget heading="Accepted Applications" value={getCount(attendees, "status", "Accepted")} />
            </Grid>
            {/* Ticket Type Distribution and Call to Action */}
            <Grid item xs={8}>
              <PieChartWidget heading="Application Overview" data={applicationsData}/>
            </Grid>
            <Grid item xs={4}>
              <NavigationPanel/>
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
