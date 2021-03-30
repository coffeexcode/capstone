import {
  Grid,
  Card,
  CardContent,
  Typography,
  TextField,
  CardActions,
  Button,
} from "@material-ui/core";
import { Document, Page } from "react-pdf";
import { v1 } from "@utils/data";
import PDFViewer from "pdf-viewer-reactjs";
import React, { useState } from "react";

/**
 * Drop-down panel for displaying additional information about an applicant
 * as well as acting on that information (i.e. accept / reject).
 * @param {fn} props.update method to propogate changes made to the list of
 * attendees to the state in components above.
 * @param {Object} props.data the data of the row these details belong to
 */
export const Details = (props) => {
  const [showPDF, setShowPDF] = useState(true);

  const lorem =
    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.";
  const acceptApplicant = async () => {
    const updatedData = { ...props.data, status: "Accepted" };
    const res = await v1.updateAttendee(updatedData);
    // PDF canvas must be teared down prior to re-render
    // they do not expose it directly, thus toggle it
    // TODO: when filtering by pending application, it get's filtered out
    // on accept/reject
    setShowPDF(false);
    props.update(updatedData);
    setShowPDF(true);
  };

  const rejectApplicant = async () => {
    const updatedData = { ...props.data, status: "Rejected" };
    const res = await v1.updateAttendee(updatedData);
    // see above explaination
    setShowPDF(false);
    props.update(updatedData);
    setShowPDF(true);
  };

  return (
    <div className="table-details">
      <Grid container spacing={3}>
        <Grid item xs={8}>
          {showPDF ? (
            <PDFViewer
              hideNavbar
              document={{
                url:
                  "https://upload.wikimedia.org/wikipedia/commons/c/cc/Resume.pdf",
              }}
            />
          ) : (
            <div></div>
          )}
        </Grid>
        <Grid item xs={4}>
          <Card variant="outlined" className="details-card">
            <CardContent>
              <Typography variant="h5" component="h2">
                {props.data.name}
              </Typography>
              <Typography color="textSecondary">{props.data.status}</Typography>
              <br />
              <TextField
                fullWidth
                multiline
                disabled
                variant="outlined"
                label="Question 1"
                defaultValue={lorem}
              />
              <br />
              <br />
              <TextField
                fullWidth
                multiline
                disabled
                variant="outlined"
                label="Question 2"
                defaultValue={lorem}
              />
              <br />
              <br />
              <TextField
                fullWidth
                multiline
                disabled
                variant="outlined"
                label="Question 3"
                defaultValue={lorem}
              />
              <br />
              <br />
            </CardContent>
            <CardActions>
              <Button
                disabled={props.data.status === "Confirmed"}
                variant="contained"
                color="primary"
                onClick={acceptApplicant}
              >
                Accept
              </Button>
              <Button
                disabled={props.data.status === "Confirmed"}
                variant="contained"
                color="secondary"
                onClick={rejectApplicant}
              >
                Reject
              </Button>
            </CardActions>
          </Card>
        </Grid>
      </Grid>
    </div>
  );
};
