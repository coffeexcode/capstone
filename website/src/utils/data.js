import download from "js-file-download";
import axios from "axios";
import { Parser } from "json2csv";

const options = {
  "Content-Type": "application/json",
  "Accept": "application/json",
  "Access-Control-Allow-Origin": "true",
};

/**
 * Retrieve dummy data on event attendees
 * @param  {...any} ids optional parameter to specify specific items
 */
export const getAttendees = async (...ids) => {
  const res = await fetch("/data/data.json", options);

  const attendees = await res.json();
  if (ids.length === 0) return attendees;

  // return only request items
  return attendees.filter(v => ids.indexOf(v.id) !== -1)
};


/**
 * Retrieve developers for the about page, just a list of all our info
 */
export const getDevelopers = async () => {
  const res = await fetch("/data/team.json", options);

  const devs = await res.json();
  return devs;
}

/**
 * Accept currently selected applicant rows in the database
 * @param {*} e 
 * @param {*} data 
 */
export const acceptApplications = (e, data) => {
  // TODO
}

/**
 * Create csv file and trigger download for local file
 * @param {Object} data the rows of data to send to csv file
 */
export const exportData = async (data) => {
  try {
    const parser = new Parser(options);
    const csv = parser.parse(data);
    download(csv, "registrations.csv");
  } catch (err) {
    console.log(err);
  }
}


/**
 * Object for new api methods that interact with external API
 */
 export const v1 = {
  async getAttendees(...ids) {
    console.log(`${process.env.REACT_APP_API}/api/users/`);
    const res = await fetch(`http://localhost:5001/api/users/`, options);
    console.log(res);
    const attendees = await res.json();
    console.log(attendees);
    if (ids.length === 0) return attendees;
  
    // return only request items
    return attendees.filter(v => ids.indexOf(v.id) !== -1)
  }
}

export const getFromAPI = async (...ids) => {
 
}