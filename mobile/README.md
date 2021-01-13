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

You will need the following to serve the app.
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
After running the below, Expo's Metro Bundler will compiles the JS code using Babel and serve it to an Expo app.
```
expo start
```

The Expo app should have opened the development server on your browser. In the bottom left, set the *Connection* to *Tunnel*.

On your device (available on both Android and iOS), download the Expo app. Scan the QR Code on your browser with your system camera, the Expo app should have been prompted to open. The app will be bundled and downloaded on your device and can be opened from the app.