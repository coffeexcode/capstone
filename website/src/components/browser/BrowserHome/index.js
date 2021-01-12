import React from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@browser/FilterSidebar";
import { NumberWidget } from "@admin/common/NumberWidget";
import { EventWidget } from "@browser/EventWidget";
import "./dashboard.css";

/**
 * Component for the /admin landing page
 * See README for figma links to mockup design
 * @param {*} props
 */
export const BrowserHome = (props) => {

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
            Conferences
          </Typography>
          <Grid container spacing={2}>
<<<<<<< HEAD
            {/* Collection of conferences*/}
            <Grid className="application-metric" item xs={4}>
              <ConferenceWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="money.jpg" title="Finance Workshop" desc={"Learn about money."} events={["Learn","Eat"]}/>
            </Grid>

            <Grid className="application-metric" item xs={4}>
            <ConferenceWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="supersmash.png" title="Smash Tournament" desc={"Compete in a local Smash torunament."} events={["Opening Ceremonies","Eat"]}/>
            </Grid>

            <Grid className="application-metric" item xs={4}>
            <ConferenceWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="hack.png" title="Hackathon" desc={"Make apps and compete for prizes."} events={["Hack","Eat", "Hack"]}/>
            </Grid>
            
=======
            {/* Application/Event Traffic overview */}
            <Grid className="application-metric" item xs={4}>
              <EventWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="money.jpg" title="Finance Workshop" />
            </Grid>
            <Grid className="application-metric" item xs={4}>
            <EventWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="money.jpg" title="Finance Workshop" />

            </Grid>
            <Grid className="application-metric" item xs={4}>
            <EventWidget date="Thu, Jan 28, 2021 6:30 PM EST" image="money.jpg" title="Finance Workshop" />

            </Grid>
>>>>>>> Added conference browser.
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
