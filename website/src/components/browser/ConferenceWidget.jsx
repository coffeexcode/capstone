import React from "react";
import {
  Card,
  CardContent,
  CardMedia,
  Typography,
  Divider,
  Modal,
  Button,
  Backdrop
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
    if (!registered){
      window.open("https://l1a5ob6zkr4.typeform.com/to/vd6lDfrY", '_blank');
    }
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
        {props.events.map((e,i)=><li key={i}>{e}</li>)}
      </ul>
      <Divider/>
      <Button data-testid="registerbutton" style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleRegister}>
        {registered ? "Unregister" : "Register"}
      </Button>
      {registered ? 
        <Button data-testid="sponsorbutton" style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleSponsorship}>
        {sponsored ? "Unsponsor" : "Sponsor"}
      </Button> : ""}
      {registered ? 
        <Button data-testid="remindbutton" style={{marginTop:"5px"}} variant="outlined" color="primary" onClick={handleReminder}>
        {reminder ? "Don't Remind Me" : "Remind Me"}
      </Button> : ""}
    </div>
  );

  return (
    <div className="event-widget">
      <Card className="event-widget-card" >
        <CardContent data-testid="opencard" onClick={handleOpen}>

          <CardMedia data-testid="media" component="img" image={props.image} title="money" className="event-pic"/>

          <Typography data-testid="date" color="error" component="h6" variant="h6">
            {props.date}
          </Typography>

          <Typography data-testid="title" color="textPrimary" component="h5" variant="h5">
            {props.title}
          </Typography>

        </CardContent>
        <Modal
            data-testid='modal'
            style={{display:'flex',alignItems:'center',justifyContent:'center'}}
            open={open}
            onClose={handleClose}
            aria-labelledby="simple-modal-title"
            aria-describedby="simple-modal-description"
            BackdropComponent={Backdrop}
          >
            {details}
          </Modal>
      </Card>
    </div>
  )
}