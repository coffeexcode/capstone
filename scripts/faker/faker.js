/**
 * Data generating script for development purposes in the
 * ConAssist Capstone Project (2020-21)
 */

const faker = require('faker');
const fs = require('fs');

var data = {
  users: [],
}

const getTicketType = () => {
  const num = faker.random.number(3);
  return ['Standard', 'Full-Access', 'VIP'][num];
}

for (let i = 0; i < 2000; i++) {
  // Feel free to ammend this USER type as needed during development
  // @edavidj for PR review if you intend to do so.
  const user = {
    name: faker.name.findName(),
    email: faker.internet.email(),
    address: {
      street: faker.address.streetAddress(),
      city: faker.address.city(),
      country: "United States of America",
      state: faker.address.state(),
      zipCode: faker.address.zipCode(),
    },
    age: faker.random.number({'min': 18, 'max': 90}),
    phone: faker.phone.phoneNumber(),
    ticket: getTicketType(),
  }
  data.users = data.users.concat([user]);
}

// TODO: Generate EVENT level information, such as scheduling

// This file will need to be moved to the location outlined in the admin site README
fs.writeFileSync('data.json', JSON.stringify(data));
