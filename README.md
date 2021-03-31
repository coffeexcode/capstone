# ConAssist
## Meta
**Prepared by**: Big Yikes
* Gabriel Gebril - 400054023
* Nathan Brown - 400082002
* Steven Luu - 400084241
* Rico Florentino - 400062052
* Jaison Loodu - 400074835
* Ethan Johnston - 400068309

  
**Instructor:** Dr. Jacques Carette

**Course:** COMPSCI 4ZP6

**Year:** 2020/21

## About
This repository contains, or references, all source code relevant to the ConAssist Capstone project for group Big Yikes.

## Roadmap

For references from SRS to relevant code, see [`CHANGELOG.md`](CHANGELOG.md). Our group determined that the most sane option for a full-stack web and mobile service like ConAssist to meet the requirement of linking to our SRS document was through references from *all* Pull Requests to the section in the SRS document they are meant to address. 

### Direct Querying

Optionally, if you wish to go from SRS to corresponding code changes, you can navigate to the `Pull Requests` tab in the GitHub repository and change the search query to the following: `is:pr F-1`. This will pull up all related Pull Requests for functional requirement #1.

**NOTE**: Modules that are contained in their own repository, as a submodule here, will not have Pull Requests here. For these changes you *must* use the CHANGELOG.md file or the commit history in that repository.

### Labels

For categorized Pull Requests you can filter by labels on Github. For example, if you want to see changes related to the requirement for an administrative website, use the `admin website` label.

## Links
### Web Services
See project located under `/website` for all of our web based development. For a more detailed look at this part of the project, please see [`/website/README.md`](website/README.md).

### Mobile Application
See project located under `/mobile` for all of our mobile based development. For a more detailed look at this part of the project, please see [`/mobile/README.md`](mobile/README.md).

### Backend Services
**QR Code Management System**

See project located in repository [`github.com/coffeexcode/RestfulQr`](https://github.com/coffeexcode/RestfulQr), or through the submodule here located under `/Restful QR`.


**Event Mangement API**

See project located under `/EventManagementApi` for this API.  For a more detailed look at this part of the project, please see [`/EventManagementApi/README.md`](EventManagementApi/README.md).

**Attendace API**

See project located under `/AttendanceApi` for this API.  For a more detailed look at this part of the project, please see [`/AttendanceApi/README.md`](AttendanceApi/README.md).


**Registration System**

See project located in repository [`github.com/Jailoodu/RestfulRegistration`](https://github.com/Jailoodu/RestfulRegistration), or through the submodule here located under `/registration`.

**Marketing System**

See project located in repository [`github.com/Jailoodu/RestfulMarketing`](https://github.com/Jailoodu/RestfulMarketing), or through the submodule here located under `/marketing`.

### Scripts

The scripts directory contains individual scripts for purpose in any projects *development* or *testing*. Each script should be in it's own directory with a corresponding README.md file to explain it's purpose and usage. This, as opposed to inline documention in comments, allows for node or python scripts with dependency folders.
