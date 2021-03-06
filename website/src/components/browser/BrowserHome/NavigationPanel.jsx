import React from "react";
import {
  Card,
  CardContent,
  Typography,
  Divider,
  Button,
  IconButton,
} from "@material-ui/core";
import { useHistory } from "react-router-dom";
import ChevronRightIcon from '@material-ui/icons/ChevronRight';
import './dashboard.css';

/**
 * Generic component to display live feed of an integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {*} props 
 */
export const NavigationPanel = (props) => {
  const history = useHistory();

  // TODO: once we add proper support for different events 
  // redirect must account for this in the URL
  return (
    <div className="nav-panel">
      <Button
        variant="contained"
        color="primary"
        size="large"
        onClick={() => history.push('/admin/statistics')}
        endIcon={<ChevronRightIcon/>}
      >
        See more
      </Button>
    </div>
  )
}