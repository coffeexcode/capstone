import React from "react";
import { Button, Container, Grid } from "@material-ui/core";
import DonutSmallIcon from '@material-ui/icons/DonutSmall';
import AccountCircleIcon from '@material-ui/icons/AccountCircle';
import "./banner.css";

export const Banner = (props) => {

  return (
    <Container className="banner" maxWidth="lg">
      <Grid container spacing={3}>
        <Grid item xs={7}>
          <div className="brand">
            <div style={{float: "left", width: "50%"}}>
              <span className="brandIcon"><DonutSmallIcon/></span>
              <span className="brandName">ConAssist</span>
            </div>
          </div>
        </Grid>
        <Grid item xs={3}>
          <div className="navigation">
            <Grid container spacing={0.5}>
              <Grid item xs={4}><span className="link">About</span></Grid>
              <Grid item xs={4}><span className="link">Products</span></Grid>
              <Grid item xs={4}><span className="link">Downloads</span></Grid>
            </Grid>
          </div>
        </Grid>
        <Grid item xs={2}>
          <div className="login">
          Login <span className="loginIcon"><AccountCircleIcon/></span>
          </div>
        </Grid>
      </Grid>
    </Container>
  )
}