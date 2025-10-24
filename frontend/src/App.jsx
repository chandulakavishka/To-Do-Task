import React, { useState, useEffect } from "react";
import axios from "axios";
import AddTaskForm from "./components/AddTaskForm";
import TaskList from "./components/TaskList";
import "./App.css";

function App() {
 const [tasks, setTasks] = useState([]);

  // get latest data
  const getData = async () => {
    try {
      const response = await axios.get("http://localhost:8080/api/Task");
      setTasks(response.data);
    } catch (err) {
      console.error("Error fetching tasks:", err);
    }
  };

  useEffect(() => {
    getData();
  }, []);

  return (
    <div className="app-container">
      <AddTaskForm getData={getData} />
      <TaskList tasks={tasks} getData={getData} />
    </div>
  );
}

export default App
