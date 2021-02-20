# Mobile client for ConAssist

## Introduction
This directory contains the client-side code for our mobile app that will be used by all personnel  during a conference.

## About the Service

This mobile app, contains three seperate views for their respective functions during a conference. 

For POC/demo purposes, the app currently gives the user a staging screen that allows the user to utilize the app with their selection of any of those three functions
 - **Attendee**
    - View scheduled events
    - Register/unregister from events
    - See conference information
    - View sponsors at the conference
    - Present your assigned QR Code to verify identification, claim prizes and food
 - **Sponsor**:
    - View scheduled events
    - Register/unregister from events
    - Scan QR Codes to get attendee contact information
 - **Organizer**:
    - View scheduled events
    - Scan QR Codes to verify attendees, track resource consumption

### Built With

- [React Native](https://reactnative.dev/)
- [Expo](https://expo.io/)
- [React Navigation](https://reactnavigation.org/)
- [React Native Calendars](https://github.com/wix/react-native-calendars)

## Prerequisites

You will need the following to serve the app on your own mobile device.
- Expo Go app 
  - on the App Store (iOS)
  - on the Play Store (Android)

To setup the app locally. 
> The app is served on a published url on Expo, if you would like to skip the installation steps, create an account [here](https://expo.io/signup) and skip to Usage and follow the instructions on [Expo Online](#Expo-Online)
- Latest version of [Node](https://nodejs.org/en/)
- [Yarn](https://classic.yarnpkg.com/en/docs/install#windows-stable)
- Expo-CLI
  ```bash
  npm install --global expo-cli
  ```

## Installation

Clone the repository.
```
git clone https://github.com/coffeexcode/capstone.git
```
Navigate to `./capstone/mobile`.

Install dependencies for project.
```
yarn
```
## Usage

### Local
After running the below, Expo's Metro Bundler will compiles the JS code using Babel and serve it to an Expo app.
```
expo start
```

The Expo app should have opened the development server on your browser. In the bottom left, set the *Connection* to *Tunnel*.

Now, scan the QR Code on your browser with your system camera, the Expo app should have been prompted to open. The app will be bundled and downloaded on your device!

### Expo Online 

Navigate to the hosted project url at <https://expo.io/@ricoflorentino/projects/mobile>.

Scan the QR Code on your browser with your system camera, the Expo app should have been prompted to open.

## Testing

[Jest](https://jestjs.io/) and [React Native Testing Library](https://github.com/callstack/react-native-testing-library) were used to test the mobile repository.


For our unit tests you can see the commands below for running them locally, or viewing results in browser via Travis CI.

### Running Unit Tests

Whenever a branch is pushed to here, Travis CI will run the test suit and the results can be viewed [here](https://www.travis-ci.com/github/coffeexcode/capstone). For the mobile results, you can find them by clicking the job labelled `Mobile Unit Testing`. This should display the console results of testing.

To run them locally you should run the following commands from this directory:

To install dependencies for testing.
```sh
# /mobile
yarn install
```

To run the tests
```sh
yarn test
```

When the above command runs, it will generate a coverage report on all the code within `src/`. If you are interested at viewing an interactive coverage report, please view  `coverage/lcov-report/index.html`.

The static copy of the coverage report is located at `docs/coverage-report/coverage.jpg`.

### Test Locations

For respective tests for each file, they are adjacent to that file.

For example, the test for `PresentQR.js`:
```
- src
  |- screens
    |- Attendee
      |- PresentQR.js
      |- PresentQR.test.js
```

### Acceptance Testing

We found that acceptance testing, with how it relates to the UI, was only really achievable as a unit test (at least given the scale of our project). Therefore, we have labelled unit tests that directly relate to fit criterion from our SRS with `[ACCEPTANCE TEST (F-#)]` at the end of their test label. To view acceptance tests that **pass** you may need to search project for `[ACCEPTANCE TEST` in your text editor locally; failed tests will be easy to find in the results seen in travis.