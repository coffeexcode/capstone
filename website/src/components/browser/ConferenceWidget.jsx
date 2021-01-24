import React from "react";
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Divider,
  Modal,
  Button
} from "@material-ui/core";
import { makeStyles } from '@material-ui/core/styles';
import '@admin/common/common.css';


/**
 * Event card
 * @param {*} props 
 */

const useStyles = makeStyles((theme) => ({
  paper: {
    position: 'absolute',
    width: 400,
    backgroundColor: theme.palette.background.paper,
    border: '2px solid #000',
    boxShadow: theme.shadows[5],
    padding: theme.spacing(2, 4, 3),
  },
}));
function getModalStyle() {

  return {
    margin: 'auto'
  };
}
export const ConferenceWidget = (props) => {

  const classes = useStyles();
  // getModalStyle is not a pure function, we roll the style only on the first render
  const [modalStyle] = React.useState(getModalStyle);
  const [open, setOpen] = React.useState(false);
  const [registered, setRegister] = React.useState(false);
  const [sponsored, setSponsorship] = React.useState(false);
  const [reminder, setReminder] = React.useState(false);
  
  const handleOpen = () => {
    setOpen(true);
  };
  const handleClose = () => {
    setOpen(false);
  };
  const handleRegister = () => {
    setRegister(prevState => !prevState)
  };

  const handleSponsorship= () => {
    setSponsorship(prevState => !prevState)
  };

  const handleReminder= () => {
    setReminder(prevState => !prevState)
  };

  const details = (
    <div style={modalStyle} className={classes.paper}>
       <Typography color="textPrimary" component="h3" variant="h3">
            {props.title}
          </Typography>
      <Typography color="error" component="h6" variant="h6">
            {props.date}
      </Typography>
      <p id="simple-modal-description">
        {props.desc}
      </p>

      <Typography color="error" component="h6" variant="h6">
            Events
      </Typography>
      <ul>
        {props.events.map(e=><li>{e}</li>)}
      </ul>
      <Divider/>
      <Button style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleRegister}>
        {registered ? "Unregister" : "Register"}
      </Button>
      {registered ? 
        <Button style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleSponsorship}>
        {sponsored ? "Unsponsor" : "Sponsor"}
      </Button> : ""}
      {registered ? 
        <Button style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleReminder}>
        {reminder ? "Don't Remind Me" : "Remind Me"}
      </Button> : ""}
    </div>
  );

  return (
    <div className="event-widget">
      <Card className="event-widget-card" >
        <CardContent onClick={handleOpen}>

          <CardMedia component="img" image={props.image} title="money" className="event-pic"/>

          <Typography color="error" component="h8" variant="h8">
            {props.date}
          </Typography>

          <Typography color="textPrimary" component="h5" variant="h5">
            {props.title}
          </Typography>

        </CardContent>
        <Modal
            style={{display:'flex',alignItems:'center',justifyContent:'center'}}
            open={open}
            onClose={handleClose}
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
          >
            {details}
          </Modal>
      </Card>
    </div>
  )
}