import React from "react";
import {
    Card,
    CardContent,
    Typography,
    Divider,
  } from "@material-ui/core";
import { Bar } from "react-chartjs-2";

/**
 * Generic component to display live feed of an integer based statistics
 * (i.e. the current total attendees registered for an event)
 * @param {*} props 
 */
export const BarChartWidget = (props) => {
    const options = {
        scales: {
            yAxes: [
                {
                    ticks: {
                        beginAtZero: true,
                    },
                },
            ],
        },
    }

    return (
        <div className="bar-chart-widget">
            <Card className="bar-chart-widget-card">
                <CardContent>
                    <Typography color="textSecondary" component="h6" variant="h6">{props.heading}</Typography>
                    <Bar data={props.data} options={options}></Bar>
                </CardContent>
            </Card>
        </div>
    )
}