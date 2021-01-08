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
  - [Design](#design)
    - [Mockups](#mockups)
  - [Development](#development)
    - [Project Structure](#project-structure)
    - [Component Structure](#component-structure)
  - [Usage](#usage)

## About the Service

Our admin site, for the purposes of this proof of concept, contains our tools
for adminstrating your event from an organizer point of view. This largely pertains to viewing statistics about who is going to your event and, if applicable, who has applied for your event. 

The majority of pages are designed for tracking and managing these relevant statistics.

### Built With
* [React](https://reactjs.org/)
* Firebase (? - remove if not used)
* [Material UI](https://material-ui.com/)

## Getting Started
### Pre-reqs
You will need the following installed to run this site locally.
> TODO: Update this as more sophisticated requirements develop (i.e. access to the backend services, etc.)

* [Node JS](https://nodejs.org/en/)
* [yarn](https://yarnpkg.com/) (Optional)

### Installation
* Clone the repository onto your device
```sh
git clone https://github.com/coffeexcode/capstone.git
```
* Navigate to `./capstone/admin`
* Install dependencies
```sh
yarn install
```
* Run the service for development
```sh
yarn start
```
## Design
### Mockups
For design reference or to collaborate on page design see the figma
folder: `https://www.figma.com/files/project/21846921/ConAssist`
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


|  Directory 	| Function 	|
|---	|---	|
| @components  	|  Root level core website pages and components 	|
| @admin  	|  Private administrative dashboard pages and components for event organizers 	|
| @attendee  	|  Public pages and components for attendees hoping to register or apply to an event 	|
| @product | Public pages and components for service marketing and subscription management |
| @utils | JavaScript utility packages (i.e. api interaction, common functions, etc.) |

**Notes on the above**
* Common components and functionality pertaining to multiple of: admin, attendee, and product, should not go at the @component level but in the @utils directory.
* To ammend directory names to better suit their purpose, please also update `craco.config.js` as well as any existing import references that use the alias.
* Imports that refer to directories **above** themselves should **always** use the corresponding alias, there should be no `../` used.

### Component Structure

In order to leverage JavaScript auto-completion of imports where there exists an index.js our components have the following structure:
```
- <ComponentName>
  |- index.jsx
  |- HelperComponent.jsx
  |- componentname.css
```

This allows for imports to look like this:
```js
import { Component } from "@component/ComponentName"
```
Instead of this:
```js
import { Component } from "@component/ComponentName/ComponentName"
```



## Usage
TODO