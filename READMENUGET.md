HTTP response status codes
============
 [![Current Version](https://img.shields.io/badge/version-1.0.4-green.svg)](https://github.com/Endersonfs/HttpsCodeRequest)

HTTP response status codes indicate whether a specific `HTTP` request has been successfully completed.

---

## Features
- Informational responses (100 – 199)
- Successful responses (200 – 299)
- Redirection messages (300 – 399)
- Client error responses (400 – 499)
- Server error responses (500 – 599)

#### Note:
- The status codes listed below are defined by **RFC 9110**

---

## Setup
#### .net CLI
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
