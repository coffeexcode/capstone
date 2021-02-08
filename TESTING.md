# Testing ConAssist
## Introduction

Each service of our project has it's own test instructions, which will be aggregated into this section here. It is important to note that Travis CI results for this repository only pertain to *modules directly defined here*, namely the web and mobile client code. Other services will document full instructions in their respective repositories (see instructions below).

## Website

For the web based UI we have a suite of unit tests using the `@testing-library/react` library.

### Accessing Example Results

* If you visit our [https://www.travis-ci.com/github/coffeexcode/capstone](Travis CI) repository, you can view the website unit tests of the latest master build by selecting the job labelled "Website Unit Testing".

### Understanding and Running Unit Tests

* Please see the section in our websites [README](/website/README.md#running-unit-tests) for instructions regarding our unit tests.
* For information on how to connect tests to acceptance criterion from our SRS see the section on [Acceptance Testing](/website/README.md#acceptance-testing).

## Mobile Application

## ... (anything that has it's own tests)