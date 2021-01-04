import React from "react";
import { Button, Container, Grid } from "@material-ui/core";
import "./home.css";

export const Home = (props) => {

  return (
    <Container className="admin-home" maxWidth="lg">
      <Grid container spacing={3}>
        <Grid item xs={6}>
          <div className="landing-call">
            <p style={{fontSize: "24px"}}>One Platform, Any Event</p>
            <p style={{fontSize: "36px"}}>Non-profit event organizing at scale</p>
            <Button variant="contained" color="primary">Get Started</Button>
          </div>
        </Grid>
        <Grid item xs={6}>
          <img className="event-img" src="./undraw_event.svg" />
        </Grid>
      </Grid>
    </Container>
  )
}