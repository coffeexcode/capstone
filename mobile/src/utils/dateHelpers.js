const days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
const months = ['January','February','March','April','May','June','July','August','September','October','November','December'];

/**
 * Returns whether the target event has ended
 * 
 * @param {Date} startDate start date of the event
 * @returns {boolean} if the event has ended
 */
const eventHasEnded = startDate => {
  const now = new Date();
  const eventDate = new Date(startDate);
  return eventDate < now;
}

/**
 * Returns a formatted string of format YYYY-MM-DD
 * 
 * @param {Date} date to be converted into string format
 * @returns {string} date in the format of YYYY-MM-DD
 */
const agendaFormatDate = date => date.toISOString().split('T')[0];

/**
 * Returns a formatted string that is readable to the user
 * e.g January, Wednesday 13, 4 PM - 6 PM
 * 
 * @param {Date} date to be converted into string format
 * @param {number} startTime time the event begins
 * @param {number} endTime time the event ends
 * @returns {string} formatted string representing the full date
 */
const formatDate = (date, startTime, endTime) => {
  const eventDate = new Date(date);
  const dayNum = eventDate.getDay();
  const monthNum = eventDate.getMonth();
  return `${months[monthNum]}, ${days[dayNum]} ${startTime} - ${endTime}`
}

/**
 * Returns an object with all the events formatted into 'Agenda' for react-native-calendars
 * 
 * @param {object} eventData event information
 * @returns {object} formatted into 'Agenda' style 
 */
const agendaFormattedEvents = eventData => {
  return eventData.map(event => {
    const { name, description, roomId, type, status, start, end } = event;
    
    const startDate = new Date(start);
    const endDate = new Date(end);
    const startDay = agendaFormatDate(startDate);
    const endDay = agendaFormatDate(endDate);
    const startTime = startDate.toLocaleString('en-US', { hour: 'numeric', hour12: true });
    const endTime = endDate.toLocaleString('en-US', { hour: 'numeric', hour12: true });

    return {
      name,
      description,
      roomId,
      type,
      status,
      start,
      startDay,
      startTime,
      endDay,
      endTime
    }
  });
}

/**
 * Returns an object with all the Agenda events categorized into date properties for react-native-calendars
 * 
 * @param {object} eventData event information in 'Agenda' style
 * @returns {object} event object categorized into date properties
 */
const categorizeAgenda = eventData => {
  const categories = {};
    
    for (let i = 0; i < eventData.length; i++) {
      if (eventData[i].startDay in categories) {
        categories[eventData[i].startDay].push(eventData[i]);
      }
      else {
        categories[eventData[i].startDay] = [eventData[i]];
      }
    }
    return categories;
}

export {
  agendaFormatDate,
  agendaFormattedEvents,
  categorizeAgenda,
  eventHasEnded,
  formatDate
};
