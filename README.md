# Mobile client for ConAssist


## Git Stuff

Clone the repository.
```
git clone https://github.com/coffeexcode/capstone.git
```

Checkout to `mobile` branch.
> Note: If you currently have another branch open of this repository, it might be a good idea to do this on another directory. 
```
git checkout mobile
```

## Prerequisites

Before installing the required dependencies, you will need the latest version of [Node](https://nodejs.org/en/) and [Yarn](https://classic.yarnpkg.com/en/docs/install#windows-stable).

> Optional: A good tool to manage different versions of node is [nvm-windows](https://github.com/coreybutler/nvm-windows).

This project uses Expo.
```
npm install --global expo-cli
```

## Installation
Install dependencies for project.
```
yarn
```

## Run
After running the below, Expo's Metro Bundler will compiles the JS code using Babel and serve it to an Expo app.
```
expo start
```

The Expo app should have opened the development server on your browser. In the bottom left, set the *Connection* to *Tunnel*.

On your device(available on both Android and iOS), download the Expo app. Scan the QR Code on your browser with your system camera, the Expo app should have been prompted to open. The app will be bundled and downloaded on your device and can be opened from the app.