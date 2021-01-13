import React from "react";
import { Divider, Container, Grid } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import DonutSmallIcon from "@material-ui/icons/DonutSmall";
import AccountCircleIcon from "@material-ui/icons/AccountCircle";
import "./banner.css";

/**
 * Site-wide banner at top of the page
 */
export const Banner = (props) => {
  const history = useHistory();
  const redirect = (endpoint) => history.push(endpoint);
  return (
    <Container className="banner" maxWidth="lg">
      <Grid container spacing={3}>
        <Grid item xs={4}>
          <div className="brand">
            <div style={{ float: "left", width: "50%" }}>
              <span className="brandIcon">
                <DonutSmallIcon />
              </span>
              <span onClick={() => redirect("/")} className="brandName">
                ConAssist
              </span>
            </div>
          </div>
        </Grid>
        <Grid item xs={4}>
          <div className="navigation">
            <Grid container spacing={0.2}>
              <Grid item xs={3}>
                <span onClick={() => redirect("/about")} className="link">About</span>
              </Grid>
              <Grid item xs={3}>
                <span onClick={() => redirect("/products")} className="link">Products</span>
              </Grid>
              <Grid item xs={3}>
                <span onClick={() => redirect("/downloads")} className="link">Downloads</span>
              </Grid>
            </Grid>
          </div>
        </Grid>
        <Grid item xs={4}>
          <div className="navigation">
            <Grid container spacing={0.2}>
              <Grid item xs={3}>
                <span className="link" onClick={() => redirect("/admin")}>
                  Dashboard
                </span>
              </Grid>
              <Grid item xs={1}>
                <Divider orientation="vertical" />
              </Grid>
              <Grid item xs={3}>
                <span className="link">
                  <span className="login">John Doe</span>{" "}
                  <span className="loginIcon">
                    <AccountCircleIcon />
                  </span>
                </span>
              </Grid>
            </Grid>
          </div>
        </Grid>
      </Grid>
    </Container>
  );
};
