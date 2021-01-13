const options = {
  "Content-Type": "application/json",
  "Accept": "application/json",
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