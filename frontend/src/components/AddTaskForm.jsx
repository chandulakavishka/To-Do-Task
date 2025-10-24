import React, { useState } from "react";
import axios from "axios";

const AddTaskForm = ({ getData }) => {
  const [title, setTitle] = useState("");
  const [desc, setDesc] = useState("");
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const handleSubmit = async (e) => {
    e.preventDefault();
    if (!title.trim()) return;
    
    setLoading(true);
    setError(null);

    try {
      await axios.post("http://localhost:8080/api/Task", {
        title: title,
        description: desc,
        isCompleted: false
      });

      setTitle("");
      setDesc("");

      getData(); // refresh tasks

    } catch (err) {
      console.error(err);
      setError("Error adding task. Please try again.");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="add-task">
      <h3>Add a Task</h3>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Title"
          value={title}
          required
          onChange={(e) => setTitle(e.target.value)}
        />
        <textarea
          placeholder="Description"
          required
          value={desc}
          onChange={(e) => setDesc(e.target.value)}
        />
        <button type="submit" disabled={loading}>Add</button>
      </form>
      {error && <p style={{ color: "red" }}>{error}</p>}
      <div className="vl"></div>
    </div>
  );
};

export default AddTaskForm;
