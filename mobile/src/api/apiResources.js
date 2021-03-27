const dev = 'http://localhost:8080';
const prod = '';

const baseUrl = `${dev}/api/v1`;

const options = {
  headers: {
    "Content-Type": "application/json",
    "Accept": "application/json"
  }
};

const getEvents = async () => {
  try {
    let response = await fetch(`${baseUrl}/events`, options);

    const data = await response.json();
    return data;
  } catch (error) {
    console.log(error);
  }
}

const getEventOfferingById = async (id) => {
  try {
    let response = await fetch(`${baseUrl}/eventofferings/${id}`, options);

    const data = await response.json();
    return data;

  } catch (error) {
    console.log(error);
  }
}

const postEventOfferingById = async (id, data) => {
  try {
    const postOptions = {
      ...options,
      "method": "POST",
      body: JSON.stringify(data)
    };

    let response = await fetch(`${baseUrl}/eventofferings/${id}`, postOptions);

    const data = await response.json();

    return data;
  } catch (error) {
    console.log(error);
  }
};

const getCourses = async () => {
  try {
    let res = await fetch(`${baseUrl}/courses`, options);

    const data = await res.json();
    return data;
  } catch (error) {
    console.log(error);
  }
}

const getCourseOfferingById = async (id) => {
  try {
    let response = await fetch(`${baseUrl}/courseofferings/${id}`, options);

    const data = await response.json();
    return data;

  } catch (error) {
    console.log(error);
  }
}

const postCourseOfferingById = async (id, data) => {
  try {
    const postOptions = {
      ...options,
      "method": "POST",
      body: JSON.stringify(data)
    };

    let response = await fetch(`${baseUrl}/courseofferings/${id}`, postOptions);

    const data = await response.json();

    return data;
  } catch (error) {
    console.log(error);
  }
};

const getSponsors = async () => {
  try {
    let response = await fetch(`${baseUrl}/sponsors`, options);

    const data = await response.json();
    return data;
  } catch (error) {
    console.log(error);
  }
}

export {
  getEvents,
  getEventOfferingById,
  postEventOfferingById,
  getCourses,
  getCourseOfferingById,
  postCourseOfferingById,
  getSponsors
}
