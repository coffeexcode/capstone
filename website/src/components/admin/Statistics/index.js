import React from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@admin/common/Sidebar";
import "./statistics.css";
import { PieChartWidget } from "../common/PieChartWidget";
import { BarChartWidget } from "../common/BarChartWidget";
import { NumberWidget } from "../common/NumberWidget";
import { HorizontalBarChartWidget } from "../common/HorizontalBarChartWidget";
import { LineChartWidget } from "../common/LineChartWidget";

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

  const ageData = {
    labels: ['', '18', '26', '36', '46', '56', '66+', ''],
    datasets: [
      {
        label: '# of applicants',
        data: [null, 22, 37, 33, 27, 24, 13, null],
        fill: false,
        backgroundColor: 'rgba(54, 162, 235, 1)',
        borderColor:'rgba(54, 162, 235, 0.2)',
        borderWidth: 1,
        width: 200,
      },
    ],
  }

  const locationData = {
    labels: ['Boston', 'Chicago', 'New Jersey', 'New York', 'Toronto', 'Other'],
    datasets: [
      {
        label: '# of applicants',
        data: [23, 16, 14, 29, 62, 12],
        backgroundColor: [
          'rgba(75, 192, 192, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(255, 99, 132, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(54, 162, 235, 0.2)',
          'rgba(153, 102, 255, 0.2)'
        ],
        borderColor: [
          'rgba(75, 192, 192, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(255, 99, 132, 1)',
          'rgba(255, 159, 64, 1)',
          'rgba(54, 162, 235, 1)',
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
              <BarChartWidget heading="Ticket Type Distribution" data={ticketTypeData} />
            </Grid>
          </Grid>
          <Grid container spacing={2}>
            <Grid item xs={2}>
              <NumberWidget heading="Pending" value="680" />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Accepted" value="156" />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Rejected" value="78" />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Standard" value="103" />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Full-Access" value="40" />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="VIP" value="13" />
            </Grid>
          </Grid>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <LineChartWidget heading="Age Distribution" data={ageData} />
            </Grid>
            <Grid item xs={6}>
              <HorizontalBarChartWidget heading="Geographic Distribution" data={locationData} />
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
