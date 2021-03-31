<!--
This file includes ordered list of changes to the project with links to corresponding Pull Requests.

ALL Pull Requests linked should include reference to the SRS document requirements that it is trying to satisfy or address in some way, if any.

e.g 
### Added
- Added admin dashboard interface ([#1](<link_to_pr_#1>))
### Changed
- Changed admin dashboard widgets available to better fit requirements ([#2](<link_to_pr_#2>))
-->

# Changelog
All notable changes to this project will be documented in this file.

## Mobile
### Added
- Added mobile screen to sign in ([57e3adf](https://github.com/coffeexcode/capstone/commit/57e3adff75627cc3015e0de6aea4cfafbdf00df0))
- Added mobile screen to Present QR ([75f72c2](https://github.com/coffeexcode/capstone/commit/75f72c232a4990a185aac5d14c8294165ca6d739))
- Added mobile screen to Scan QR codes ([0f56699](https://github.com/coffeexcode/capstone/commit/0f56699db40f170264c931d6813e8c88da64d26d))
- Added mobile screen to view the schedule of a conference ([4ffa223](https://github.com/coffeexcode/capstone/commit/4ffa2238b79ee4b5540eabbee2a511331ff47d6f))
- Added mobile screen to view profile ([#1](https://github.com/coffeexcode/capstone/pull/1))
- Added organizer/sponsor/attendee views with their respective functions via bottom tab bar ([#3](https://github.com/coffeexcode/capstone/pull/3))
- Added About page to view conference information and sponsors ([#5](https://github.com/coffeexcode/capstone/pull/5))
- Added event page to allow users to register/withdraw from event offerings ([#10](https://github.com/coffeexcode/capstone/pull/10))
- Added functionality to allow QR Code to perform action ([#20](https://github.com/coffeexcode/capstone/pull/20))

### Changed
- Update profile and event page UI ([#86](https://github.com/coffeexcode/capstone/pull/86))
- Update event page to allow confirmation for users registering/withdrawing from event offerings ([#89](https://github.com/coffeexcode/capstone/pull/89))
## Website
### Added
- Added landing page for administrative section of the website. ([#2](https://github.com/coffeexcode/capstone/pull/2))
- Added website page for managing event applications or registrations ([#4](https://github.com/coffeexcode/capstone/pull/4))
- Added statistics page to display graphs and visual statistics ([#9](https://github.com/coffeexcode/capstone/pull/9))
- Added website pages for ConAssist team details and offering page ([#13](https://github.com/coffeexcode/capstone/pull/13))
- Added page to view events ([bfbcc43](https://github.com/coffeexcode/capstone/pull/14))
- Added page to view conferences ([bfbcc43](https://github.com/coffeexcode/capstone/pull/14))
- Added button to register for conference ([bfbcc43](https://github.com/coffeexcode/capstone/pull/14))
- Added button to set a reminder for conference ([bfbcc43](https://github.com/coffeexcode/capstone/pull/14))
- Added button to sponsor a conference ([bfbcc43](https://github.com/coffeexcode/capstone/pull/14))
- Added typeform for attendees to register to a conference ([#88](https://github.com/coffeexcode/capstone/pull/88))

### Changed
- Changed applicant management table to include drop down with details on each user, including resume and details ([#90](https://github.com/coffeexcode/capstone/pull/90))
- Changed applicant management table to allow for accepting or rejecting applications to conference ([#90](https://github.com/coffeexcode/capstone/pull/90))
- Changed applicant management table to display more complete information about each entry, including actual responses to form questions from typeform demo ([#91](https://github.com/coffeexcode/capstone/pull/91))

## Backend
### Added
#### Event Management API
- Added ability to create an event for attendees within the conference - ([F-7](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))
- Added ability to be able to view all the events they have access to within a conference. - ([F-10](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))
- Added ability to register for an event they have access to. - ([F-11](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([a21500a](https://github.com/coffeexcode/capstone/commit/a21500a8affc93f1487f3246806c4cfbb4419491))
- Added ability to withdraw from an event that they have registered for - ([F-13](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([a21500a](https://github.com/coffeexcode/capstone/commit/a21500a8affc93f1487f3246806c4cfbb4419491))
- Added ability to change event details created within a conference - ([F-14](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))
- Added ability to delete events within a conference - ([F-15](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))
- Added ability to create locations to be used within the conference - ([F-23](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))
- Added ability to book a location when creating an event - ([F-24](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([36b75a9](https://github.com/coffeexcode/capstone/commit/36b75a93d60ff215ad8ef35a0036260123e4153f))

#### Registration API
- Added REST endpoints to create and interact with user accounts ([699a6c5](https://github.com/Jailoodu/RestfulRegistration/commit/699a6c5e41b2a884352639cd666e45d9bb4bc58a)) - ([F-1](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-1))
- Added REST endpoint to review conference applications ([699a6c5](https://github.com/Jailoodu/RestfulRegistration/commit/699a6c5e41b2a884352639cd666e45d9bb4bc58a)) - ([F-21](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-21))
- Dockerized application so it can be run in various environments ([757f2e5](https://github.com/Jailoodu/RestfulRegistration/commit/757f2e5eec1960ba19bdb70b576f9b9d6a6c20bc))
- Added REST endpoint to export event attendee data ([dd20591](https://github.com/Jailoodu/RestfulRegistration/commit/dd20591ee28f3af258593a111bdee0e1ac33640c)) - ([F-38](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38))
- Added REST endpoint for users (sponsors, etc) to pay event organizers ([e00ef31](https://github.com/Jailoodu/RestfulRegistration/commit/e00ef3177cef831dd87cc9628e1d7c0ff0d6757f)) - ([F-35](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-35))

#### Marketing API
- Added REST endpoints allowing organizers to add marketing material for their conference ([289b392](https://github.com/Jailoodu/RestfulMarketing/commit/289b3923abdf193c2fe2d2227a0083ddd382b5e1)) - ([F-34](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-34))
- Added REST endpoints allowing organizers to email attendees and sponsors ([10c866d](https://github.com/Jailoodu/RestfulMarketing/commit/10c866d96ccbdf813919ebede2d61a703e86f516)) - ([F-22](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-22))

#### QR Code API
- Added ability to generate QR Codes upon registering for a conference - ([F-27](https://github.com/coffeexcode/capstone/wiki/Requirements-Document#F-38)) - ([ba54330](https://github.com/coffeexcode/RestfulQr/commit/ba54330e28b7286ce7949ef22acd7cd4cfcc3d9d))

### Changed
