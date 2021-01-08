import React from "react";
import {
  Card,
  CardContent,
  Typography,
  Divider,
  Button,
  IconButton,
} from "@material-ui/core";
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import './dashboard.css';

/**
 * Generic component to display live feed of an integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {*} props 
 */
export const NavigationPanel = (props) => {

  return (
    <div className="nav-panel">
      <Button
        variant="contained"
        color="primary"
        size="large"
        endIcon={<ChevronRightIcon/>}
      >
        See more
      </Button>
    </div>
  )
}