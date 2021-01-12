import React from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@admin/common/Sidebar";
import "./statistics.css";
import { PieChartWidget } from "../common/PieChartWidget";
import { BarChartWidget } from "../common/BarChartWidget";

/**
 * Component for the /admin landing page
 * See README for figma links to mockup design
 * @param {*} props
 */
export const Statistics = (props) => {
  const applicationsData = {
    labels: ['Pending', 'Accepted', 'Rejected'],
    datasets: [
      {
        data: [680, 156, 78],
        backgroundColor: [
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(255, 99, 132, 0.2)'
        ],
        borderColor: [
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(255, 99, 132, 1)'
        ],
        borderWidth: 1,
        width: 200,
      },
    ],
  }

  const ticketTypeData = {
    labels: ['Standard', 'Full-Access', 'VIP'],
    datasets: [
      {
        label: '# of Applicants',
        data: [103, 40, 13],
        backgroundColor: [
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(153, 102, 255, 0.2)'
        ],
        borderColor: [
          'rgba(54, 162, 235, 1)',
          'rgba(255, 159, 64, 1)',
          'rgba(153, 102, 255, 1)'
        ],
        borderWidth: 1,
        width: 200,
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
            variant="h4">
            Event Statistics
          </Typography>
          <Grid container spacing={2}>
            {/* Application/Event Traffic overview */}
            <Grid item xs={6}>
              <PieChartWidget heading="Application Status" data={applicationsData} />
            </Grid>
            <Grid item xs={6}>
              <BarChartWidget heading="Ticket Type Distribution (Accepted)" data={ticketTypeData} />
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
