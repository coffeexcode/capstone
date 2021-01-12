import React from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@admin/common/Sidebar";
import { NumberWidget } from "@admin/common/NumberWidget";
import { NavigationPanel } from "./NavigationPanel";
import { PieChartWidget } from "@admin/common/PieChartWidget";
import "./dashboard.css";

/**
 * Component for the /admin landing page
 * See README for figma links to mockup design
 * @param {*} props
 */
export const Dashboard = (props) => {

  const applicationsData = {
    labels: ['Pending', 'Accepted'],
    datasets: [
      {
        label: '# of Votes',
        data: [156, 680],
        backgroundColor: [
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)'
        ],
        borderColor: [
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)'
        ],
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
              <NumberWidget heading="Pending Applications" value="680" />
            </Grid>
            <Grid className="application-metric" item xs={4}>
              <NumberWidget heading="Event Views" value="2670" />
            </Grid>
            <Grid className="application-metric" item xs={4}>
              <NumberWidget heading="Accepted Applications" value="156" />
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