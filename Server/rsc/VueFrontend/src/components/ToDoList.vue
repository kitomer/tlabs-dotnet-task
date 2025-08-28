<template>
  <div class="formContainer">
    <div class="createToDoItemContainer">
      <input
        class="createInput"
        v-model="newTask"
        @keyup.enter="addTask"
        placeholder="Add a new todo"
      />
      <button class="createButton" @click="addTask">Add</button>
    </div>
    <div class="toDoListContainer">
      <div v-for="task in todos" :key="task.id">
        <div class="toDoRow">
          <input type="checkbox" @change="updateTask(task)" v-model="task.isCompleted" />
          <input
            :class="{ completed: task.isCompleted, editInput: true }"
            v-model="task.title"
            @blur="updateTask(task)"
            @keyup.enter="updateTask(task)"
          />
          <button class="deleteButton" @click="deleteTask(task)">Delete</button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { ref, computed, defineComponent } from "vue";
import { useToDoStore } from "../stores/toDoStore.js";

export default defineComponent({
  name: "ToDoList",
  async setup() {
    const todoStore = useToDoStore();
    const todos = computed(() => todoStore.tasks);

    await todoStore.fetchTasks();

    const newTask = "";

    const addTask = () => {
      if (newTask.trim()) {
        todoStore.addTask({ title: newTask, isCompleted: false });
        newTask = "";
      }
    };

    const deleteTask = async (task) => {
      await todoStore.deleteTask(task);
    };

    const updateTask = async (task) => {
      await todoStore.editTask(task);
    };

    return {
      todos,
      newTask,
      addTask,
      deleteTask,
      updateTask,
    };
  },
});
</script>

<style scoped>
.completed {
  text-decoration: line-through;
}

.toDoListContainer {
  display: flex;
  flex-direction: column;
  gap: 10px;
  margin-top: 30px;
}

.createToDoItemContainer {
  display: flex;
  flex-direction: row;
  gap: 10px;
}

.formContainer {
  display: flex;
  flex-direction: column;
  margin-left: auto;
  margin-right: auto;
  width: 400px;
}

.createButton {
  margin-right: auto;
  margin-left: 0;
  width: 50px;
}

.toDoRow {
  display: flex;
  gap: 10px;
}

.deleteButton {
  margin-right: auto;
  margin-left: 0;
  width: 50px;
}

.updateButton {
  margin-right: auto;
  margin-left: 0;
  width: 60px;
}

.createInput {
  flex-grow: 1;
}

.editInput {
  flex-grow: 1;
}
</style>
