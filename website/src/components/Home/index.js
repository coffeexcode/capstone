import React from "react";
import { Button, Container, Grid } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import "./home.css";

/**
 * Landing page for the entire website
 */
export const Home = (props) => {
  const history = useHistory();
  const redirect = (endpoint) => history.push(endpoint);
  return (
    <div>
      <Container className="admin-home" maxWidth="lg">
        <Grid container spacing={3}>
          <Grid className="home-row" item xs={6}>
            <div className="landing-call">
              <p style={{ fontSize: "24px" }}>One Platform, Any Event</p>
              <p style={{ fontSize: "36px" }}>
                Non-profit event organizing at scale
              </p>
              <Button variant="contained" color="primary">
                Get Started
              </Button>
            </div>
          </Grid>
          <Grid item xs={6}>
            <img className="event-img" src="./img/undraw_event.svg" />
          </Grid>
          <Grid className="browse-row" item xs={6}>
            <img className="browse-img" src="./img/browse.svg" />
          </Grid>
          <Grid className="browse-row" item xs={6}>
            <div className="landing-call">
              <p style={{ fontSize: "24px" }}>Find an event today</p>
              <p style={{ fontSize: "36px" }}>Browse events in your area</p>
              <Button onClick={() => redirect("/browse")} variant="contained" color="primary">
                Browse
              </Button>
            </div>
          </Grid>
        </Grid>
      </Container>
      <div className="bg-color"></div>
    </div>
  );
};
