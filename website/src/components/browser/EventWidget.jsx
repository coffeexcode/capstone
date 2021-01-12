import React from "react";
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Divider,
} from "@material-ui/core";
import '@admin/common/common.css';

/**
 * Generic component to display live feed of an integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {*} props 
 */
export const EventWidget = (props) => {

  return (
    <div className="event-widget">
      <Card className="event-widget-card">
        <CardContent>

          <CardMedia component="img" image={props.image} title="money" className="event-pic"/>

          <Typography color="error" component="h8" variant="h8">
            {props.date}
          </Typography>

          <Typography color="textPrimary" component="h5" variant="h5">
            {props.title}
          </Typography>

        </CardContent>
      </Card>
    </div>
  )
}