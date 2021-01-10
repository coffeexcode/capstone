const options = {
  "Content-Type": "application/json",
  "Accept": "application/json",
};

export const getAttendees = async (...ids) => {
  const res = await fetch("/data/data.json", options);

  const attendees = await res.json();
  if (ids.length === 0) return attendees;

  // return only request items
  return attendees.filter(v => ids.indexOf(v.id) !== -1)
};
