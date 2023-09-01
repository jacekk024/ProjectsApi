# ProjectsApi

An API for managing portfolio projects. Create, update, delete, and retrieve projects from your portfolio. Incorporate links, descriptions, technologies used, and more.

## Features

* CRUD Operations: Easily manage your projects:
    * Create new projects.
    * Retrieve details of your projects.
    * Update existing projects.
    * Delete projects.
* Rich Details:
    * Provide links to repositories.
    * Describe your projects with rich descriptions.
    * List the technologies used in each project.

## Installation & Setup
1. Clone the Repository:
 ```git clone https://github.com/jacekk024/ProjectsApi```
2. Navigate to the project directory:
```cd ProjectsApi```
3. Run project solution *.sln
## Usage
1. Start your application: Ensure that the API is running either locally or on its hosted environment.
2. Open a browser: Navigate to the following URL:
```
    http://localhost:PORT/swagger/index.html
```

### GET
Request:
```
    GET /api/Projects
```
Response Body:
```
    [
    {
    "id": 1,
    "title": "Stock-App",
    "description": "Finance App",
    "repositoryUrl": "https://github.com/jacekk024/Stock-App",
    "technologiesUsed": "React Native,JavaScript",
    "dateAdded": "2023-09-01T10:38:29.814"
    },
    {
    "id": 3,
    "title": "Keyboard-Master",
    "description": "App for training speed of typing",
    "repositoryUrl": "https://github.com/jacekk024/Keyboard-Master",
    "technologiesUsed": "C#,.NET Core,WPF,MVVM",
    "dateAdded": "2023-09-01T10:38:29.814"
    },
    {
    "id": 4,
    "title": "Portfolio",
    "description": "My personal web page",
    "repositoryUrl": "https://github.com/jacekk024/portfolio",
    "technologiesUsed": "html,js,css",
    "dateAdded": "2023-09-01T10:54:22.076"
    }
    ]
```

Request:
```
    GET /api/Projects/{1}
```

Response Body:
```
    {
    "id": 1,
    "title": "Stock-App",
    "description": "Finance App",
    "repositoryUrl": "https://github.com/jacekk024/Stock-App",
    "technologiesUsed": "React Native,JavaScript",
    "dateAdded": "2023-09-01T10:38:29.814"
    }  
```




