import React from "react";
import {
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Divider,
} from "@material-ui/core";
import { useHistory } from "react-router-dom";
import '@admin/common/common.css';

/**
 * Component for sidebar navigation on admin side of the website.
 * @param {*} props 
 */
export const Sidebar = (props) => {
  const history = useHistory();

  return (
    <div className="admin-sidebar">
      <List component="admin-nav">
        <ListItem  button>
          <ListItemText primary="All" />
        </ListItem>
        <Divider/>
        <Divider/>
        <ListItem  button>
          <ListItemText primary="Today" />
        </ListItem>
        <Divider/>
        <Divider/>
        <ListItem  button>
          <ListItemText primary="Free" />
        </ListItem>
        <Divider/>
        <ListItem  button>
          <ListItemText primary="Education" />
        </ListItem>
        <Divider/>
        <ListItem  button>
          <ListItemText primary="Food and Drink" />
        </ListItem>
        <Divider/>
        <ListItem button>
          <ListItemText primary="Charity and Causes" />
        </ListItem>
      </List>
    </div>
  )
}