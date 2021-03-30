import {
  getEvents,
  getEventOfferingById,
  postEventOfferingById,
  getCourses,
  getCourseOfferingById,
  postCourseOfferingById,
  getSponsors
} from './apiResources';


global.fetch = jest.fn(() => Promise.resolve({ json:() => {} }));

beforeEach(() => {
  fetch.mockClear();
});

describe('apiResources', () => {
  
  it('should fetch the events from the api', async () => {

    await getEvents();

    expect(fetch).toHaveBeenCalled();
  })

  it('should get the event offering by id', async () => {
    
    mockId = 'event-id';

    await getEventOfferingById(mockId);

    expect(fetch).toHaveBeenCalled();
  })

  it('should update the event offering by id', async () => {
    
    mockId = 'event-id';
    mockBody = {
      status: 'REGISTERED'
    }

    await postEventOfferingById(mockId, mockBody);

    expect(fetch).toHaveBeenCalled();
  })

  it('should fetch the courses from the api', async () => {

    await getCourses();

    expect(fetch).toHaveBeenCalled();
  })

  it('should fetch the course offering by id', async () => {

    mockId = 'event-id';
    
    await getCourseOfferingById(mockId);

    expect(fetch).toHaveBeenCalled();
  });

  it('should update the course offering by id', async () => {
    
    mockId = 'event-id';
    mockBody = {
      status: 'REGISTERED'
    }

    await postCourseOfferingById(mockId, mockBody);

    expect(fetch).toHaveBeenCalled();
  })

  it('should get the sponsor data from the api', async () => {

    await getSponsors();

    expect(fetch).toHaveBeenCalled();
  })

  it('should catch any failures in any of the requests', async () => {
    fetch.mockImplementation(() => Promise.reject(500));

    await getEvents();
    await getEventOfferingById();
    await postEventOfferingById();
    await getCourses();
    await getCourseOfferingById();
    await postCourseOfferingById();
    await getSponsors();

    expect(fetch).toHaveBeenCalled();
  })
})
