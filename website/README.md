# ConAssist Admin Website

## Introduction

This directory contains the clientside code for our administrative services.

- [ConAssist Admin Website](#conassist-admin-website)
  - [Introduction](#introduction)
  - [About the Service](#about-the-service)
    - [Built With](#built-with)
  - [Getting Started](#getting-started)
    - [Pre-reqs](#pre-reqs)
    - [Installation](#installation)
  - [Unit Testing](#unit-testing)
    - [Running Unit Tests](#running-unit-tests)
    - [Writing Unit Tests](#writing-unit-tests)
  - [Acceptance Testing](#acceptance-testing)
  - [Design](#design)
    - [Mockups](#mockups)
  - [Development](#development)
    - [Project Structure](#project-structure)
    - [Component Structure](#component-structure)
    - [Accessing Data](#accessing-data)
  - [Usage](#usage)

## About the Service

Our admin site, for the purposes of this proof of concept, contains our tools
for adminstrating your event from an organizer point of view. This largely pertains to viewing statistics about who is going to your event and, if applicable, who has applied for your event.

The majority of pages are designed for tracking and managing these relevant statistics.

### Built With

- [React](https://reactjs.org/)
- [Material UI](https://material-ui.com/)
- [Chart.js](https://www.chartjs.org/)

## Getting Started

### Pre-reqs

You will need the following installed to run this site locally.

> TODO: Update this as more sophisticated requirements develop (i.e. access to the backend services, etc.)

- [Node JS](https://nodejs.org/en/)
- [yarn](https://yarnpkg.com/) (Optional)

### Installation

- Clone the repository onto your device

```sh
git clone https://github.com/coffeexcode/capstone.git
```
- Navigate to `./capstone/website`
- Install dependencies

```sh
yarn install
```

- Run the service for development

```sh
yarn start
```

## Unit Testing

For our unit tests you can see the commands below for running them locally, or viewing results in browser via Travis CI. R

### Running Unit Tests

Whenever a branch is pushed to here, Travis CI will run the test suit and the results can be viewed [here](https://www.travis-ci.com/github/coffeexcode/capstone). For the website results, you can find them by clicking the job labelled `Website Unit Testing`. This should display the console results of testing.

To run them locally you should run the following commands from this directory:
```sh
# /website
yarn install -- --watchAll

# run tests with coverage output generated
yarn test -- --coverage --watchAll=false

# OR just run tests
yarn test
```

Either of these commands will give you the number of pass/fail unit tests, expanding on the error message for all the failed tests. Given some of these tests are looking for components *not yet implemented* they will occasional spit out huge chunks of react elements to help you figure out why it couldn't find that component, so there will be a lot of output from these test commands locally.

If you ran it with the coverage flags turned on, you will get a handy table in the console output indicating the coverage for each test/folder. If you would like to see this in more detail you can find the html file version of that table at `/coverage/lcov-report/index.html`.

### Writing Unit Tests

See `src\components\Banner\banner.test.js` for a **very** simple example of a test you can run. Typically, to start, we just want to test that expected links and elements exist on the page correctly. This would later be followed up with tests that simulate button clicks, etc., etc.

## Acceptance Testing

We found that acceptance testing, with how it relates to the UI, was only really achievable as a unit test (at least given the scale of our project). Therefore, we have labelled unit tests that directly relate to fit criterion from our SRS with `[ACCEPTANCE TEST (F-#)]` at the end of their test label. To view acceptance tests that **pass** you may need to search project for `[ACCEPTANCE TEST` in your text editor locally; failed tests will be easy to find in the results seen in travis.

## Design

### Mockups

For design reference or to collaborate on page design see the figma
folder: `https://www.figma.com/files/project/21846921/ConAssist`. 

It is not necessary for all pages to have mockups here, but all designs should be strictly compatible thematically with what is seen there.

## Development

### Project Structure

As seen in the diagram below, we have categorized our React components into directories of related requirement fullfilment.

```
- src
  |- components [@components]
    |- admin [@admin]
    |- attendee [@attendee]
    |- product [@product]
  |- utils [@utils]
```

> Figure 1 - Documented directory structure, strings enclosed in brackets correspond to that directories import alias (see `craco.config.js` for alias definition)

**Directory Definitions**
| Directory   | Function                                                                          |
| ----------- | --------------------------------------------------------------------------------- |
| @components | Root level core website pages and components                                      |
| @admin      | Private administrative dashboard pages and components for event organizers        |
| @attendee   | Public pages and components for attendees hoping to register or apply to an event |
| @product    | Public pages and components for service marketing and subscription management     |
| @utils      | JavaScript utility packages (i.e. api interaction, common functions, etc.)        |

**Notes on the above**

- Common components and functionality pertaining to multiple of: admin, attendee, and product, should not go at the @component level but in the @utils directory.
- To ammend directory names to better suit their purpose, please also update `craco.config.js` as well as any existing import references that use the alias.
- Imports that refer to directories **above** themselves should **always** use the corresponding alias, there should be no `../` used in import strings.

### Component Structure

In order to leverage JavaScript auto-completion of imports where there exists an index.js our components have the following structure:

```
- <ComponentName>
  |- index.jsx
  |- HelperComponent.jsx
  |- componentname.css
```

This allows for imports to look like this, while still keeping each components unique sub-components and stylesheet definitions separate:

```js
import { Component } from "@component/ComponentName";
```

Instead of this:

```js
import { Component } from "@component/ComponentName/ComponentName";
```

### Accessing Data

Currently we generate fake data using the faker script located at `/scripts/faker`. To access the json file generated by this you must first follow instructions provided in that script's README to add the file to public files for the website.

Once there you should **always** access data by importing the utility package `@utils/data`:

```js
import { getAttendees } from "@utils/data";

const testFunction = async () => {
  const attendees = await getAttendees();
  console.log(attendees);
}
```

If this package does not have a method for the data you are trying to access, add it instead of defining it directly in your component. This allows us to avoid code duplication as well as rapidly adjust where this data is coming from as the backend API matures.

## Usage

TODO
