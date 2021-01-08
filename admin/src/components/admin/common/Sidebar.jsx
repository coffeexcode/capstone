import React from "react";
import {
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Divider,
} from "@material-ui/core";
import './common.css';

/**
 * Component for sidebar navigation on admin side of the website.
 * @param {*} props 
 */
export const Sidebar = (props) => {

  return (
    <div className="admin-sidebar">
      <List component="admin-nav">
        <ListItem button>
          <ListItemText primary="Statistics" />
        </ListItem>
        <Divider/>
        <ListItem button>
          <ListItemText primary="Applications" />
        </ListItem>
        <Divider/>
        <ListItem button>
          <ListItemText primary="Manage Data" />
        </ListItem>
        <Divider/>
        <ListItem button>
          <ListItemText primary="Help" />
        </ListItem>
      </List>
    </div>
  )
}