import React from "react";
import {
    Card,
    CardContent,
    Typography,
    Divider,
  } from "@material-ui/core";
import { Line } from "react-chartjs-2";

/**
 * Generic component to display live feed of statistics in the form of a line chart
 * (i.e. the current total attendees registered for an event)
 * @param {string} props.heading The label for this data point
 * @param {object} props.data The statistical data and formatting for the chart.
 */
export const LineChartWidget = (props) => {
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
        <div className="line-chart-widget">
            <Card className="line-chart-widget-card">
                <CardContent>
                    <Typography color="textSecondary" component="h6" variant="h6">{props.heading}</Typography>
                    <Line data={props.data} options={options}></Line>
                </CardContent>
            </Card>
        </div>
    )
}