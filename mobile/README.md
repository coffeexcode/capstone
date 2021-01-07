# Mobile client for ConAssist

## Introduction
This directory contains the client-side code for our mobile app that will be used by all personnel (organizers/vendors/attendees) during a conference.

## Prerequisites

You will need the following to serve the app.
- Latest version of [Node](https://nodejs.org/en/)
- [Yarn](https://classic.yarnpkg.com/en/docs/install#windows-stable)
- Expo-CLI
  ```
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