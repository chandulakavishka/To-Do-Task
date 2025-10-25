import React from "react";
import axios from "axios";
import API from "../api";

const TaskList = ({ tasks, getData }) => {

  
  const taskDone = async (id) => {
    try {
      await API.put(`/Task/${id}/done`);
      getData(); // get latest data
    } catch (err) {
      console.error("Error marking task done:", err);
    }
  };

  return (
     <div className="task-list">
      {tasks.map((task) => (
        <div
          key={task.id}
          className="task-card"
        >
          <div className="task-card-info">
            <h4>{task.title}</h4>
            <p>{task.description}</p>
          </div>
         
            <button onClick={() => taskDone(task.id)}>Done</button>
          
        </div>
      ))}
    </div>
  );
};

export default TaskList;
