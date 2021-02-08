import React from "react";
import {
  Card,
  CardContent,
  Typography,
  Divider,
} from "@material-ui/core";
import './common.css';

/**
 * Generic component to display integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {string} props.value The number to display in the integer data widget
 * @param {string} props.heading The label for this data point
 * @param {object} props.data The statistical data and formatting for the chart.
 */
export const NumberWidget = (props) => {

  return (
    <div className="number-widget">
      <Card className="number-widget-card">
        <CardContent>
          <Typography color="textSecondary" variant="inherit">{props.heading}</Typography>
          <Typography color="textPrimary" variant="h4">
            {props.value}
          </Typography>
        </CardContent>
      </Card>
    </div>
  )
}