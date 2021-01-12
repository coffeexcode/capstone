const days = ['Sunday','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday'];
const months = ['January','February','March','April','May','June','July','August','September','October','November','December'];

const eventHasEnded = startDate => {
  const now = new Date();
  const eventDate = new Date(startDate);
  return eventDate < now;
}

const agendaFormatDate = date => date.toISOString().split('T')[0];

const formatDate = (date, startTime, endTime) => {
  const eventDate = new Date(date);
  const dayNum = eventDate.getDay();
  const monthNum = eventDate.getMonth();
  return `${months[monthNum]}, ${days[dayNum]} ${startTime} - ${endTime}`
}

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