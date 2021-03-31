import React, { useEffect, useState} from "react";
import { Container, Grid, Typography } from "@material-ui/core";
import { Sidebar } from "@admin/common/Sidebar";
import "./statistics.css";
import { PieChartWidget } from "../common/PieChartWidget";
import { BarChartWidget } from "../common/BarChartWidget";
import { NumberWidget } from "../common/NumberWidget";
import { HorizontalBarChartWidget } from "../common/HorizontalBarChartWidget";
import { LineChartWidget } from "../common/LineChartWidget";
import { v1, transformTypeFormData } from "@utils/data";
import { getCount, getCountNot, getCountRange, getTopLocations, getSumOfLocationsCount } from "@utils/stats";

/* Component for the /admin/statistics page */
export const Statistics = (props) => {
  
  const [attendees, setAttendees] = useState([]);
  
  const getData = async () => {
    const rows = await v1.getAttendees();
    console.log(rows)
    setAttendees(transformTypeFormData(rows));
  };

  useEffect(() => {
    getData();
  }, []);

  // Data for application status pie chart and number cards
  const applicationsData = {
    labels: ['Pending', 'Accepted', 'Rejected'],
    datasets: [
      {
        data: [getCount(attendees,"status", "Pending"), getCount(attendees,"status", "Accepted"), getCount(attendees,"status", "Rejected")],
        backgroundColor: [
          'rgba(255, 206, 86, 0.2)',
          'rgba(75, 192, 192, 0.2)',
          'rgba(255, 99, 132, 0.2)'
        ],
        borderColor: [
          'rgba(255, 206, 86, 1)',
          'rgba(75, 192, 192, 1)',
          'rgba(255, 99, 132, 1)'
        ],
        borderWidth: 1,
        width: 200,
      },
    ],
  }

  // Data for ticket type bar chart
  const occupationData = {
    labels: ['Student', 'Adult', 'Total'],
    datasets: [
      {
        label: '# of Applicants',
        data: [getCount(attendees,"occupation", "Student"), getCountNot(attendees,"occupation", "Student"), attendees.length],
        backgroundColor: [
          'rgba(54, 162, 235, 0.2)',
          'rgba(255, 159, 64, 0.2)',
          'rgba(153, 102, 255, 0.2)'
        ],
        borderColor: [
          'rgba(54, 162, 235, 1)',
          'rgba(255, 159, 64, 1)',
          'rgba(153, 102, 255, 1)'
        ],
        borderWidth: 1,
        width: 200,
      },
    ],
  }

  // Data for age distribution line chart
  const ageData = {
    labels: ['', '18-25', '26-35', '36-45', '46-55', '56-65', '66+', ''],
    datasets: [
      {
        label: '# of applicants',
        data: [null, getCountRange(attendees, "age", 18, 25), getCountRange(attendees, "age", 26, 35), getCountRange(attendees, "age", 36, 45),
          getCountRange(attendees, "age", 46, 55), getCountRange(attendees, "age", 56, 65), getCountRange(attendees, "age", 66, 999), null],
        fill: false,
        backgroundColor: 'rgba(54, 162, 235, 1)',
        borderColor:'rgba(54, 162, 235, 0.2)',
        borderWidth: 1,
        width: 200,
      },
    ],
  }
  
  // locations object array: [{state : string, count : number}], array is sorted by count in descending order
  const locations = getTopLocations(attendees);

  // Data for geographic distribution horizontal bar chart
  const locationData = {
    labels: locations.slice(0,2).map(l  => l.location).concat(["Other"]),
    datasets: [
      {
        label: '# of applicants',
        data: locations.slice(0,2).map(l => l.count).concat([getSumOfLocationsCount(locations, 2)]),
        backgroundColor: [
          'rgba(75, 192, 192, 0.2)',
          'rgba(255, 206, 86, 0.2)',
          'rgba(255, 99, 132, 0.2)',
          //'rgba(255, 159, 64, 0.2)',
          //'rgba(54, 162, 235, 0.2)',
          //'rgba(153, 102, 255, 0.2)'
        ],
        borderColor: [
          'rgba(75, 192, 192, 1)',
          'rgba(255, 206, 86, 1)',
          'rgba(255, 99, 132, 1)',
          //'rgba(255, 159, 64, 1)',
          //'rgba(54, 162, 235, 1)',
          //'rgba(153, 102, 255, 1)'
        ],
        borderWidth: 1,
        width: 200,
      },
    ],
  }

  return (
    <Container data-testid="statistics-page" className="dashboard" maxWidth="lg">
      <Grid container spacing={5}>
        <Grid item xs={3}>
          <Sidebar />
        </Grid>
        <Grid item xs={9}>
          <Typography
            className="dashboard-title"
            color="textSecondary"
            component="h4"
            variant="h4">
            Event Statistics
          </Typography>
          <Grid container spacing={2}>
            {/* Application/Event Traffic overview */}
            <Grid item xs={6}>
              <PieChartWidget heading="Application Status" data={applicationsData} />
            </Grid>
            <Grid item xs={6}>
              <BarChartWidget heading="Occupation Distribution" data={occupationData} />
            </Grid>
          </Grid>
          <Grid container spacing={2}>
            <Grid item xs={2}>
              <NumberWidget heading="Pending" value={getCount(attendees, "status", "Pending")} />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Accepted" value={getCount(attendees, "status", "Accepted")} />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Rejected" value={getCount(attendees, "status", "Rejected")} />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Student" value={getCount(attendees, "occupation", "Student")} />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Adult" value={getCountNot(attendees, "occupation", "Student")} />
            </Grid>
            <Grid item xs={2}>
              <NumberWidget heading="Total" value={attendees.length} />
            </Grid>
          </Grid>
          <Grid container spacing={2}>
            <Grid item xs={6}>
              <LineChartWidget heading="Age Distribution" data={ageData} />
            </Grid>
            <Grid item xs={6}>
              <HorizontalBarChartWidget heading="Geographic Distribution" data={locationData} />
            </Grid>
          </Grid>
        </Grid>
      </Grid>
    </Container>
  );
};
