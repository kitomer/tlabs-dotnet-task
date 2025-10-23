import { defineStore } from "pinia";

export const useToDoStore = defineStore("toDoStore", {
  state: () => ({
    tasks: [],
  }),
  actions: {
    fetchTasks() {
      // get tasks from localhost:5000/api/tasks
      fetch("http://localhost:5000/api/tasks")
        .then((response) => response.json())
        .then((data) => {
          this.tasks = data;
        });
    },
    async addTask(task) {
      await fetch("http://localhost:5000/api/tasks", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
      }).finally(() => {
        this.fetchTasks();
      });
    },

    async editTask(task) {
      let body = JSON.stringify(task);
      await fetch(`http://localhost:5000/api/tasks/${task.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(task),
      }).finally(() => {
        this.fetchTasks();
      });
    },

    async deleteTask(task) {
      let task_id = task.id;
      await fetch(`http://localhost:5000/api/tasks/${task_id}`, {
        method: "DELETE",
        headers: {
          "Content-Type": "application/json",
        },
      }).finally(() => {
        this.fetchTasks();
      });
    },
  },
});
