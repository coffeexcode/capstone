import React from "react";
import {
    Card,
    CardContent,
    Typography,
    Divider,
  } from "@material-ui/core";
import { HorizontalBar } from "react-chartjs-2";

/**
 * Generic component to display live feed of statistics in the form of a horizontal bar chart
 * (i.e. the current total attendees registered for an event)
 * @param {string} props.heading The label for this data point
 * @param {object} props.data The statistical data and formatting for the chart.
 */
export const HorizontalBarChartWidget = (props) => {
    const options = {
        scales: {
            xAxes: [
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
                    <HorizontalBar data={props.data} options={options}></HorizontalBar>
                </CardContent>
            </Card>
        </div>
    )
}