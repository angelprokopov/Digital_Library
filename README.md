# Digital Library System

An integrated solution for barcode scanning, book management, and seamless data visualization across web and mobile platforms.

## Overview

This repository consists of three interconnected projects designed to manage a digital library:

API: A backend service that integrates with Google Books API to fetch book details and manage the library database.

Mobile App: An Android application for scanning book barcodes, retrieving details via the API, and displaying information.

Blazor Web App: A web-based application for managing and viewing the digital library in a responsive UI.

Together, these components enable efficient book management, from barcode scanning to data visualization.

## System Architecture

## Diagram
Below is a simplified diagram illustrating how the API, Mobile App, and Blazor Web App interact within the system:
```
[ Mobile App ] -> [ API ] -> [ Database ]
       |
       v
[ Google Books API ]
```
## Components

1. Mobile App:

* Scans ISBN barcodes using the device camera.

* Sends the ISBN to the API for book details.

* Displays book information on the device.

2. API:

* Fetches book details from Google Books API.

* Stores book data in a SQL Server database.

* Provides endpoints for book retrieval and searching.

3. Blazor Web App:

* Fetches book data from the API and database.

* Displays books in a table or card layout.

* Allows users to search for and manage book details.

### Prerequisites

## Common Requirements
* .NET 6.0 SDK or higher
* SQL Server (local or Azure)
* Android SDK and Android Studio (for the mobile app)

## Project-Specific Requirements

| Project          | Requirements  |
| ---------------- | ------------- |
| API              | Entity Framework Core, AutoMapper, Swagger  |
| Mobile App       | Retrofit, ZXing Barcode Scanner library     |
| Blazor Web App   | Blazor Server                               |

# Project Details
API Project

Overview

The backend service that integrates with the Google Books API to fetch book details and stores them in a SQL Server database.

Features
* Fetch book details by ISBN.
* Search books by title.
* Store book data in a structured database.

## Production API Link
https://bookdetailsapi.azurewebsites.net/

## API Endpoints
* GET /api/Books/{isbn}: Fetch book details by ISBN
* GET /api/Books/GET /api/Books/search?title={title}: Search books by title.
# Mobile App

Overview

An Android application that scans book barcodes, retrieves details from the API, and displays them to the user.

Features
* Scan book barcodes using ZXing.
* Fetch book details via the API.
* Display book details to the user.

# Blazor Web App

Overview

A web-based application for managing and visualizing the digital library.

Features
* Search and view book details.
* Display books in a responsive card or table layout.
* Manage stored books.

## Future Enhancements

Below are some potential future improvements for the system. They are listed in order of priority to guide contributors:

1. Add user authentication to the API and Blazor app:
    * Context: This would enhance security and allow for user-specific features like personal book collections or borrowing history.
    * Priority: High

2. Implement a book lending feature in the Blazor app:
    * Context: Enable users to borrow and return books through the web interface, tracking due dates and availability.
    * Priority: Medium

3. Enhance the mobile app with offline capabilities:
    * Context: Allow the app to store scanned book data locally when offline, syncing with the server once reconnected.
    * Priority: Medium

4. Add advanced search and filtering options in the web app:
    * Context: Improve usability by allowing users to search books by various criteria (e.g., genre, author) and apply filters.
    * Priority: Low
