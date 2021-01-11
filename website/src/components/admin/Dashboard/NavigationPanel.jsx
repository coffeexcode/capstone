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
 * Component for the panel on landing admin dashboard that provides a button
 * to redirect to the statistics page. A call-to-action element. 
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