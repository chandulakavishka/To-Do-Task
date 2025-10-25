# To-Do Task Management Application

This is a full-stack To-Do Task Management application built with **ASP.NET Core**, **ReactJS**, and **MySQL**. The project is fully containerized using Docker.

---

## Running the Application with Docker

1. **Navigate to the project root directory** (where `docker-compose.yml` is located):

```bash
cd <your-project-root-folder>
````

2. **Build and start the containers**:

```bash
docker-compose up --build
```

This will:

* Build backend and frontend Docker images.
* Start MySQL, backend, and frontend containers.
* Automatically create the database `todo_db`.

3. **Check running containers and their ports**:

```bash
docker ps
```

You should see something like:

| Container Name | Ports              | Purpose          |
| -------------- | ------------------ | ---------------- |
| todo-frontend  | 0.0.0.0:5173->80   | React frontend   |
| todo-backend   | 0.0.0.0:8080->8080 | ASP.NET Core API |
| mysql          | 0.0.0.0:3307->3306 | MySQL Database   |


4. **Access the Application**:

* Frontend (React app): [http://localhost:5173](http://localhost:5173)
* Backend API (ASP.NET Core): [http://localhost:8080](http://localhost:8080)

5. **Stop and remove all containers**:

```bash
docker-compose down
```

Add a note like:

⚠️ Port Conflicts: If Docker fails to bind ports, make sure no other processes are using them. You can change host ports.
