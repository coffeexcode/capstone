import { 
  agendaFormatDate, 
  agendaFormattedEvents,
  categorizeAgenda,
  eventHasEnded,
  formatDate
} from '@utils/dateHelpers';

describe('dateHelpers', () => {
  
  const today = new Date();
  const testDate = new Date(2021, 0, 1);
  const event = {
    name: 'TestEvent',
    description: 'Test description',
    roomId: 'testId',
    type: 'testType',
    status: 'testStatus',
    start: testDate,
    end: testDate
  }

  describe('eventHasEnded', () => {
    it('should return true if the specified event date has ended', () => {
       const yesterday = new Date(today);
       yesterday.setDate(today.getDate() - 1);

       const returned = eventHasEnded(yesterday);

       expect(returned).toBe(true);
    })

    it('should return false if the specified event date has not ended', () => {
      const tomorrow = new Date(today);
      tomorrow.setDate(today.getDate() + 1);
      
      const returned = eventHasEnded(tomorrow);

      expect(returned).toBe(false);
    })
  });

  describe('agendaFormatDate', () => {
    it('should return a properly formatted Agenda-styled date', () => {
      const returned = agendaFormatDate(testDate);
      expect(returned).toBe('2021-01-01');
    })
  });

  describe('formatDate', () => {
    it('should return a properly formatted string', () => {
      const testProps = {
        date: testDate,
        startTime: 7,
        endTime: 10
      }
      const returned = formatDate(
        testProps.date,
        testProps.startTime,
        testProps.endTime
      );
  
      expect(returned).toBe('January, Friday 7 - 10');
    })
  });

  describe('agendaFormattedEvents', () => {
    it('should return an object of formatted events', () => {
      const { name, description, roomId, type, status, start } = event;
      
      const returned = agendaFormattedEvents([event]);
      expect(returned[0]).toStrictEqual({
        name, 
        description,
        roomId,
        type,
        status,
        start,
        startDay: '2021-01-01',
        startTime: '12 AM',
        endDay: '2021-01-01',
        endTime: '12 AM'
      });
    })
  })

  describe('categorizeAgenda', () => {
    it('should return an object of categorized agenda events', () => {
      const testAgendaFormattedEvents = agendaFormattedEvents([event]);

      const returned = categorizeAgenda(testAgendaFormattedEvents);
      expect(returned).toStrictEqual({
        '2021-01-01': [testAgendaFormattedEvents[0]]
      });
    })

    it('should place two events on the same day under the same date in the same category', () => {
      const newTestEvent = {
        name: 'NewTestEvent',
        description: 'Test description new',
        roomId: 'testId-new',
        type: 'testTypeNew',
        status: 'testStatusNew',
        start: testDate,
        end: testDate
      }

      const testAgendaFormattedEvents = agendaFormattedEvents([event, newTestEvent]);
      const returned = categorizeAgenda(testAgendaFormattedEvents);
      expect(returned).toStrictEqual({
        '2021-01-01': [testAgendaFormattedEvents[0], testAgendaFormattedEvents[1]]
      });
    })

    it('should place two events on different days under different categories', () => {
      const newTestDate = new Date(2021, 1, 1);

      const newTestEvent = {
        name: 'NewTestEvent',
        description: 'Test description new',
        roomId: 'testId-new',
        type: 'testTypeNew',
        status: 'testStatusNew',
        start: newTestDate,
        end: newTestDate
      }

      const testAgendaFormattedEvents = agendaFormattedEvents([event, newTestEvent]);
      const returned = categorizeAgenda(testAgendaFormattedEvents);

      expect(returned).toStrictEqual({
        '2021-01-01': [testAgendaFormattedEvents[0]],
        '2021-02-01': [testAgendaFormattedEvents[1]]
      })
    })
  })
})
