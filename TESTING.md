# Testing ConAssist
## Introduction

Each service of our project has it's own test instructions, which will be aggregated into this section here. It is important to note that Travis CI results for this repository only pertain to *modules directly defined here*, namely the web and mobile client code. Other services will document full instructions in their respective repositories (see instructions below).

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

## ... (anything that has it's own tests)

## EventManagement API
This API uses NUnit for tests. Currently the tests are not run from CI. You must run `dotnet test` from the project directory.
