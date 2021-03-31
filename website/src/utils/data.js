import download from "js-file-download";
import axios from "axios";
import { Parser } from "json2csv";
import { ListItemAvatar } from "@material-ui/core";

const options = {
  "Content-Type": "application/json",
  Accept: "application/json",
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
  return attendees.filter((v) => ids.indexOf(v.id) !== -1);
};

/**
 * Retrieve developers for the about page, just a list of all our info
 */
export const getDevelopers = async () => {
  const res = await fetch("/data/team.json", options);

  const devs = await res.json();
  return devs;
};

/**
 * As the data received from the TypeForm setup to handle applications is
 * impractical for rendering event statistics, this helper will transform
 * those objects into more readable form
 * @param {[]Object} data List of applications
 * @returns {[]Object} List of applications in the form [fieldname] -> response
 */
export const transformTypeFormData = (data) => {
  return data
    .filter((l) => l.form_response.answers.length == 9)
    .map((row) => {
      const item = {
        id: row.id,
        name: row.form_response.answers[0].text,
        email: row.form_response.answers[4].email,
        location: row.form_response.answers[8].choice.label,
        phone: row.form_response.answers[3].phone_number,
        age:
          new Date().getFullYear() -
          new Date(row.form_response.answers[1].date).getFullYear(),
        status: row.status,
        occupation: row.form_response.answers[2].text,
        question1: row.form_response.answers[5].text,
        question2: row.form_response.answers[6].text,
        question3: row.form_response.answers[7].text,
      };
      return item;
    });
};

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
};

/**
 * Object for new api methods that interact with external API
 */
export const v1 = {
  async getAttendees(...ids) {
    const res = await fetch(`http://localhost:5001/api/users/`, options);
    const attendees = await res.json();
    if (ids.length === 0) return attendees;

    // return only request items
    return attendees.filter((v) => ids.indexOf(v.id) !== -1);
  },
  async updateAttendee(data) {
    console.log("updating...");
    const res = await axios.put(
      `http://localhost:5001/api/users/${data.id}`,
      data
    );
    return res;
  },
};
