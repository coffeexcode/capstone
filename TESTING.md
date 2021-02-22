# Testing ConAssist
## Introduction

Each service of our project has it's own test instructions, which will be aggregated into this section here. It is important to note that Travis CI results for this repository only pertain to *modules directly defined here*, namely the web and mobile client code. Other services will document full instructions in their respective repositories (see instructions below).

## Testable Artifacts

Below are instructions for students testing ConAssist for the second portion of the testing mark in the course. None of these tests should take more than 5-10 minutes of your time, if you are hung up on an error you can report it and move on to the next section.

### Getting Started

In order to complete several of the sections below, you will need access to a private Git repository that houses most of the ConAssist project. Please email `brownn11@mcmaster.ca` or message `Nathan Brown` on Teams for access to this repository.

### Mobile Application

To get the mobile application working, see details in the mobile apps [README](https://github.com/coffeexcode/capstone/blob/master/mobile/README.md#prerequisites).

Once you have managed to set this up, please try out the following:



Any feedback is welcome, in particular if we could get opinions on [...] we would appreciate that.

### Registration API

To get this REST api running on your local machine you will need docker setup on your computer. See [docker desktop](https://www.docker.com/products/docker-desktop) for Mac or Windows PCs, or your distributions package manager for linux.

Once you have docker installed run the following command to get the API:

```sh
docker run -d -p 5001:5001 edavidj/conassist-register
```

To verify that this setup has succeeded, navigate to your browser and paste the URL `http://localhost:5001/api/` into it. A Swagger UI API browser should appear, with the ability to list the exposed endpoints of this REST API. If this *does not work*, please email `johnse20@mcmaster.ca` or `Ethan Johnston` on Teams to report the issue.

Once you have completed the above setup, please perform the following sequence of tasks, verifying they work:

1. List all users by running the following command:
```sh
curl http://localhost:5001/api/users/
```
2. Pick any user id, indicated by the `id` field in the json outputted to your console, and user it for the following command:
```sh
curl http://localhost:5001/api/users/<id>
```
3. Using the same user id, delete the user using the following command (this is generated test data):
```sh
curl -X DELETE http://localhost:5001/api/users/<id>
```
4. Repeat the command listed in *Step 2*, verifying that the delete was successful.

To report a **failure** of any steps above, please open an issue under `https://github.com/Jailoodu/RestfulRegistration/issues` describing what went wrong. For general feedback or to indicate that it was completed with no issue, you can email `johnse20@mcmaster.ca` or message `Ethan Johnston` on Teams.

### Website

To get the website running in your browser locally, see details in the website [README](https://github.com/coffeexcode/capstone/tree/master/website#installation).

Once you have managed to get this running locally, please follow the instructions below:

1. `http://localhost:3000/`
2. Click on `Dashboard` in the banner of the website to the top-right.
3. Click on the `See More` button.
4. Click on the `Manage Registrations` navigation button on the left.
5. Select several rows of the data table, two buttons should appear at the top of the table. Click on the 'Export' button (hover for tooltip), and ensure a csv file is generated.

This part of the project is still in a somewhat mockup stage, with no connection to our database or api. We are primarily looking for feedback on design and visuals here. That said, outside of the above steps, feel free to navigate around what exists of the website and record thoughts or feedback. When you are done you can email `johnse20@mcmaster.ca` or message `Ethan Johnston` on Teams with any feedback you might have or just to indicate you've finished trying it out. 

## Website

For the web based UI we have a suite of unit tests using the `@testing-library/react` library.

### Accessing Example Results

* If you visit our [Travis CI](https://www.travis-ci.com/github/coffeexcode/capstone) repository, you can view the website unit tests of the latest master build by selecting the job labelled "Website Unit Testing".

### Understanding and Running Unit Tests

* Please see the section in our websites [README](/website/README.md#running-unit-tests) for instructions regarding our unit tests.
* For information on how to connect tests to acceptance criterion from our SRS see the section on [Acceptance Testing](/website/README.md#acceptance-testing).

## Mobile Application

For the mobile client, the test suite uses the `@testing-library/react-native` library.

### Accessing Example Results

* If you visit our [Travis CI](https://www.travis-ci.com/github/coffeexcode/capstone) repository, you can view the mobile unit tests of the latest master build by selecting the job labelled "Mobile Unit Testing". 

### Understanding and Running Unit Tests

* Please see the section in our mobiles [README](/mobile/README.md#testing) for instructions regarding the unit tests.
* For information on how to connect tests to acceptance criterion from our SRS see the section on [Acceptance Testing](/mobile/README.md#acceptance-testing)

## Registration API

For the Registration API, the test suite uses the `pytest` framework.

### Accessing Example Results

* If you visit our [Travis CI](https://travis-ci.org/github/Jailoodu/RestfulRegistration) repository, you can view the results of the test suite for the latest master build.

### Understanding and Running Unit Tests

* Please see the section in the [README](https://github.com/Jailoodu/RestfulRegistration/blob/main/README.md#testing) for instructions regarding the tests.
* With regards to the acceptance tests, comments have been placed within each test case detailing which requirement is being tested.

## Marketing API

For the Marketing API, the test suite uses the `pytest` framework.

### Accessing Example Results

* If you visit our [Travis CI](https://travis-ci.org/github/Jailoodu/RestfulMarketing) repository, you can view the results of the test suite for the latest master build.

### Understanding and Running Unit Tests

* Please see the section in the [README](https://github.com/Jailoodu/RestfulMarketing#testing) for instructions regarding the tests.
* With regards to the acceptance tests, comments have been placed within each test case detailing which requirement is being tested.

## EventManagement API
This API uses NUnit for tests. Currently the tests are not run from CI. You must run `dotnet test` from the project directory.

## ... (anything that has it's own tests)


