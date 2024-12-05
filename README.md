HTTP response status codes
============
 [![Current Version](https://img.shields.io/badge/version-1.0.3-green.svg)](https://github.com/Endersonfs/HttpsCodeRequest)

HTTP response status codes indicate whether a specific `HTTP` request has been successfully completed.

---
## Buy me a coffee

Whether you use this project, have learned something from it, or just like it, please consider supporting it by buying me a coffee, so I can dedicate more time on open-source projects like this :)

<a href="https://bmc.link/endfs" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/orange_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a>

---

## Features
- Informational responses (100 – 199)
- Successful responses (200 – 299)
- Redirection messages (300 – 399)
- Client error responses (400 – 499)
- Server error responses (500 – 599)

#### Note:
- The status codes listed below are defined by **<a href="https://httpwg.org/specs/rfc9110.html#overview.of.status.codes" target="_blank">RFC 9110</a>**
<!-- - **Moderator:** The above plus the ability to kick and ban users
- **Administrator:** All the above plus send global alerts and promote/demote users -->

---

## Setup
#### .net CLI  .net 7
 - dotnet add package HttpsCodeRequest --version 1.0.2

---

## Usage

>Directive import

 - using HttpsCodeRequest;

>Return Value (OK)

 - Console.WriteLine(HttpsCode.OK); 

>Return Code (200)

 - Console.WriteLine((int)HttpsCode.OK); 

>Return Descrption

 - Console.WriteLine(HttpsCode.OK.GetDescription());

 - Console.WriteLine(HttpStatusCode.GetDescriptionByCode(HttpsCode.Continue));


<!-- --- -->

<!-- ## License
>You can check out the full license [here](https://github.com/IgorAntun/node-chat/blob/master/LICENSE)

This project is licensed under the terms of the **MIT** license. -->
