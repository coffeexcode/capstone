import React from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@browser/FilterSidebar";
import { ConferenceWidget } from "@browser/ConferenceWidget";
import "./dashboard.css";

/**
 * Component for the /browser
 * @param {*} props
 */





export const BrowserHome = (props) => {
  const [open, setOpen] = React.useState(false);

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
            
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
