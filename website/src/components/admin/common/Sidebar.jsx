import React from "react";
import { List, ListItem, ListItemText, Divider } from "@material-ui/core";
import { useHistory } from "react-router-dom";
import "./common.css";

/**
 * Component for sidebar navigation on admin side of the website.
 */
export const Sidebar = (props) => {
  const history = useHistory();

  const redirect = (page) => {
    history.push(`/admin/${page}`);
  };

  return (
    <div className="admin-sidebar">
      <List component="admin-nav">
        <ListItem
          data-testid="statistics"
          onClick={() => redirect("statistics")}
          button
        >
          <ListItemText primary="Statistics" />
        </ListItem>
        <Divider />
        <ListItem
          data-testid="registrations"
          onClick={() => redirect("registrations")}
          button
        >
          <ListItemText primary="Manage Registration" />
        </ListItem>
      </List>
    </div>
  );
};
