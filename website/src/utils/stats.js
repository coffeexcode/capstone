const options = {
  "Content-Type": "application/json",
  "Accept": "application/json",
};

/**
 * Returns the count of a specific property from a data object array
 * e.g. # of applicants accepted
 * @param {Array.Object} data Object array of faker data
 * @param {string} field Name of the property (e.g. status)
 * @param {string} value The value of the property you want to find the count for (e.g. Accepted)
 */
export const getCount = (data, field, value) => {
  return data.filter(v => v[field] === value).length
};

/**
 * Returns the count of a range of a specific property from a data object array
 * e.g. # of applicants between the ages of 18 and 25
 * @param {Array.Object} data Object array of faker data
 * @param {string} field Name of the property (e.g. age)
 * @param {string} value1 The lowerbound range of the property you want to find the count for (e.g. 18)
 * @param {string} value1 The upperbound range of the property you want to find the count for (e.g. 25)
 */
export const getCountRange = (data, field, value1, value2) => {
  return data.filter(v => (v[field] >= value1 && v[field] <= value2)).length
};

/**
 * Returns a sorted (desc) object array of the top states applicants are located at and their count
 * i.e. [{state : New York, count : 24}, {state : Chicago, count : 13}, ...]
 * @param {Array.Object} data Object array of faker data
 */
export const getTopLocations = (data) => {
  var locations = [];
  var index;
  /* For each entry in data, add it to the locations object array with a count of 0 (if it doesn't exist),
     or increment the location's count by 1 */
  for (var i = 0; i < data.length; i++) {
    index = locations.map(function(l) { return l.state }).indexOf(data[i].address.state);
    if (index === -1) {
      locations.push({ state : data[i].address.state, count : 0 })
    }
    else {
      locations[index].count++;
    }
  }
  // Sort the locations by count in descending order
  locations= locations.sort((a, b) => b.count - a.count)
  return locations;
}

/**
 * Returns the sum of location counts (from getTopLocations) starting at an index to the end
 * @param {Array.Object} data Object array of faker data
 * @param {Array.Object} start starting index
 */
export const getSumOfLocationsCount = (locations, start) => {
  var ans = 0;
  // Sum all the locations' count starting from the specified index
  for (var i = start; i < locations.length; i++) {
    ans += locations[i].count;
  }
  return ans;
}
