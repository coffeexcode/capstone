import React from "react";
import {
  Card,
  CardContent,
  Typography,
  Divider,
} from "@material-ui/core";
import { Pie } from "react-chartjs-2"
import './common.css';

/**
 * Generic component to display live feed of an integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {*} props 
 */
export const PieChartWidget = (props) => {

  return (
    <div className="pie-chart-widget">
      <Card className="pie-chart-widget-card">
        <CardContent>
          <Typography color="textSecondary" component="h6" variant="h6">{props.heading}</Typography>
          <Pie data={props.data}></Pie>
        </CardContent>
      </Card>
    </div>
  )
}