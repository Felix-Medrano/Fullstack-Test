# Fullstack-Test
Create a web application that consumes data from a public API (jsonplaceholder) through a backend developed in .NET Core and displays it interactively and responsively on the frontend.

---

# 🌐 Backend Service

This project is a backend based on **ASP.NET Core** for managing various entities such as posts, comments, albums, photos, tasks, and users. It implements multiple endpoints for performing **CRUD** operations and filtering data.

## 🚀 Requirements

- .NET Core SDK `6.0` or higher
- IDE compatible (Visual Studio 2022, Visual Studio Code, Rider, etc.)

## 📦 Installation

Follow these steps to install and run the project on your local environment:

1. **Clone the repository**  
```bash
   git clone https://github.com/Felix-Medrano/Fullstack-Test.git
```
2. Open a terminal and navigate to the backend project directory.
3. **Restore NuGet packages**  
```bash
   dotnet restore
```
5. **Run the project**  
```bash
   dotnet run
```
7. **Access the Swagger documentation at:**  
   `http://localhost:5000/swagger/index.html`

## 📚 API Endpoints

### 📝 Posts

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllPosts | Gets all posts.
GET    | /Placeholder/GetPostById/{id} | Gets a post by its ID.
GET    | /Placeholder/GetPostByUserId/{userId} | Gets all posts of a user.
POST   | /Placeholder/CreatePost | Creates a new post.
PUT    | /Placeholder/UpdatePost/{id} | Updates a post by its ID.
PATCH  | /Placeholder/PatchPost/{id} | Partially updates a post by its ID.
DELETE | /Placeholder/DeletePost/{id} | Deletes a post by its ID.

### 💬 Comments

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllComments | Gets all comments.
GET    | /Placeholder/GetCommentById/{id} | Gets a comment by its ID.
GET    | /Placeholder/GetCommentsByPostId/{postId} | Gets all comments of a post.
GET    | /Placeholder/GetCommentsByEmail/{email} | Gets all comments by email.

### 📸 Photos

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllPhotos | Gets all photos.
GET    | /Placeholder/GetPhotoById/{id} | Gets a photo by its ID.
GET    | /Placeholder/GetPhotosByAlbumId/{albumId} | Gets all photos of an album by its ID.

### 📂 Albums

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllAlbums | Gets all albums.
GET    | /Placeholder/GetAlbumById/{id} | Gets an album by its ID.
GET    | /Placeholder/GetAlbumsByUserId/{userId} | Gets all albums of a user by its ID.

### 📋 ToDos

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllToDos | Gets all tasks.
GET    | /Placeholder/GetToDoById/{id} | Gets a task by its ID.
GET    | /Placeholder/GetToDosByUserId/{userId} | Gets all tasks of a user by its ID.

### 👤 Users

Method | Endpoint | Description
------ | -------- | -----------
GET    | /Placeholder/GetAllUsers | Gets all users.
GET    | /Placeholder/GetUserById/{id} | Gets a user by its ID.
GET    | /Placeholder/GetUserByName/{name} | Gets a user by its name.
GET    | /Placeholder/GetUserByUsername/{username} | Gets a user by its username.
GET    | /Placeholder/GetUserByEmail/{email} | Gets a user by its email.

### 📖 Swagger

This project includes automatically generated documentation with Swagger, where you can explore and test all endpoints.
Access it at:
`http://localhost:5000/swagger/index.html`

### 🤝 Contributions

If you want to contribute to the project:
1. Fork the repository.
2. Create a new branch:
```bash
git checkout -b feature/new-feature
```
3. Make your changes and commit your contributions:
```bash
git commit -m "Add new feature"
```
5. Push your changes to your fork:
```bash
git push origin feature/new-feature
```
6. Open a Pull Request in the original repository.

---

# Frontend

This project is the frontend part of the Fullstack-Test application. It is built using React and communicates with a backend to fetch and display data.

## How to Start the Project

To start the local server for the frontend, follow these steps:

1. Make sure you have [![Node.js](https://img.shields.io/badge/-Node.js-339933?style=flat&logo=node.js&logoColor=white)](https://nodejs.org/) installed on your machine.
2. Open a terminal and navigate to the frontend project directory.
3. Run the following command to install the dependencies:
```Bash
npm install
```
4. Once the dependencies are installed, start the development server with:
```bash
npm run dev
```
5. The project should automatically open in your browser at http://localhost:5001. If it does not open automatically, manually enter the URL in your browser.
 
## Component Descriptions

### AlbumComponent.tsx
This component is responsible for displaying a list of albums. It allows users to view the details of each album and search for albums by Id or User Id.

### CommentComponent.tsx
This component displays a list of comments. It is designed to allow users to view comments associated with specific posts or items.

### PhotoComponent.tsx
This component presents a photo gallery. Users can navigate through the photos and view additional details about each image.

### PostComponent.tsx
This component manages the display of posts. It allows users to read posts and possibly interact with them, such as commenting or sharing.

### ToDoListComponent.tsx
This component displays a list of to-do tasks. Users can view the status of each task (completed or not completed), filter tasks by their status, and search by title.

### UserComponent.tsx
This component is responsible for displaying information about users. It allows viewing details of each user.

---

## Utility Scripts

### create-component.js

The `create-component.js` script is a utility tool designed to streamline the creation of new React components within the project. By running this script, developers can quickly generate the necessary files and boilerplate code for a new component, ensuring consistency and saving time during development.

- Navigate to the frontend project directory in your console to use it.

### Example Commands

```bash
  npm run cc name path
```

### Description:

- name: The simple name of the component. The script automatically appends the suffix Component. For example, if you provide 'ABC', it will create ABC folder, ABCComponent.tsx, ABCComponent.css.

- path (optional): Specifies the path where the component should be created, e.g., ./src/components. If the directory does not exist, it will be created. If no path is provided, the component will be created in the default path shown in the console.

---

## 📝 License

This project is licensed under the MIT license. Consult the LICENSE file for more information.
