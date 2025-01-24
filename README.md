# Fullstack-Test
Create a web application that consumes data from a public API (jsonplaceholder) through a backend developed in .NET Core and displays it interactively and responsively on the frontend.

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
   cd /path/to/your/directory
```

3. **Restore NuGet packages**  
```bash
   dotnet restore
```

5. **Run the project**  
```bash
   dotnet run
```

7. **Access the Swagger documentation at:**  
   `http://localhost:5049/swagger/index.html`

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
`http://localhost:5049/swagger/index.html`

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

### 📝 License

This project is licensed under the MIT license. Consult the LICENSE file for more information.
