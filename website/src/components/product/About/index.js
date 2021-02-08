import React, { useState, useEffect } from "react";
import {
  Container,
  Grid,
  List,
  ListItem,
  ListItemAvatar,
  ListItemText,
  Avatar,
  Typography,
} from "@material-ui/core";
import { useHistory } from "react-router-dom";
import { getDevelopers } from "@utils/data";
import "./about.css";

/**
 *  Page for information on our team and our company
 */
export const About = (props) => {
  const [devs, setDevs] = useState([]);

  const getData = async () => {
    const developers = await getDevelopers();
    setDevs(developers);
  };

  useEffect(() => {
    if (props.developers) {
      setDevs(props.developers);
    } else {
      getData();
    }
  }, []);

  return (
    <div data-testid="about-page">
      <Container className="admin-home" maxWidth="lg">
        <Grid container spacing={3}>
          <Grid className="home-row" item xs={6}>
           <Typography
              className="about-title"
              color="textSecondary"
              component="h5"
              variant="h5"
            >
              About us
            </Typography>
            <p>
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.
            </p>
          </Grid>
          <Grid item xs={6}>
            <img className="event-img" src="./img/teamspirit.svg" />
          </Grid>
          <Grid className="browse-row" item xs={6}>
            <img className="team-img" src="./img/team.svg" />
          </Grid>
          <Grid className="browse-row" item xs={6}>
            <Typography
              className="dashboard-title"
              color="textSecondary"
              component="h5"
              variant="h5"
            >
              Our Team
            </Typography>
            <Grid container spacing={2}>
              {devs.map((dev, i) => (
                <Grid key={i} item xs={6}>
                  <ListItem>
                    <ListItemAvatar>
                      <Avatar alt={dev.name} src={dev.github_img} />
                    </ListItemAvatar>
                    <ListItemText primary={dev.name} secondary={dev.role} />
                  </ListItem>
                </Grid>
              ))}
            </Grid>
          </Grid>
        </Grid>
      </Container>
      <div className="bg-color"></div>
    </div>
  );
};
