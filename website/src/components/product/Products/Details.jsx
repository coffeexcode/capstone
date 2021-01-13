import React from "react";
import {
  Card,
  CardContent,
  CardHeader,
  Avatar,
  CardMedia,
  Typography,
} from "@material-ui/core";

/**
 * Show details about our product offering for the about page
 * @param {string} props.heading Title of the product offering
 * @param {string} props.subheading Pricing of the product
 * @param {string} props.product_description Details about that product tier
 */
export const Details = (props) => {
  return (
    <div className="product-details">
      <Card className="product-details-card">
        <CardContent>
          {/* <Typography color="textSecondary" component="h6" variant="h6">{props.heading}</Typography> */}
          <CardHeader
            title={props.heading}
            subheader={props.subheading}
          />
          <CardMedia
            style={{ height: "200px"}}
            image="/img/undraw_event.svg"
            title="event image"
          />
          <CardContent>
            <Typography variant="body2" color="textSecondary" component="p">
              {props.product_description}
            </Typography>
          </CardContent>
        </CardContent>
      </Card>
    </div>
  );
};
