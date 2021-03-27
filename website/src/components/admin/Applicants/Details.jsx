import { Grid, Card, CardContent, Typography } from "@material-ui/core";
import { Document, Page } from "react-pdf";
import PDFViewer from 'pdf-viewer-reactjs';
import React from "react";

export const Details = (props) => {

  return (
    <div className="table-details">
      <Grid container spacing={3}>
        <Grid item xs={6}>
          <PDFViewer document={{url: "https://upload.wikimedia.org/wikipedia/commons/c/cc/Resume.pdf"}} />
        </Grid>
        <Grid item xs={6}>
          <Card variant="outlined">
            <CardContent>
              <Typography variant="h5" component="h2">
                {props.data.name}
              </Typography>
              <Typography variant="h5" component="h2">
                TODO
              </Typography>
            </CardContent>
          </Card>
        </Grid>
      </Grid>
    </div>
  )
}